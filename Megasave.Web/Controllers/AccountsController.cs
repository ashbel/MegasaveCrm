using Megasave.Application.Contracts.Persistence;
using Megasave.Identity;
using Megasave.Identity.Models;
using Megasave.Web.Models.Identity;
using Megasave.Web.Models.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Megasave.Web.Controllers
{
    public class AccountsController : Controller
    {
        //private readonly ICustomEmailSender _emailSender;
        private IPasswordHasher<Users> _passwordHasher;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;
        private readonly MopaneIdentityDbContext _context;
        private readonly IBranchRepository _branchRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public AccountsController(
            UserManager<Users> usrMgr,
            RoleManager<IdentityRole> roleMgr,
            IPasswordHasher<Users> passwordHash,
            MopaneIdentityDbContext context, IBranchRepository branchRepository, IDepartmentRepository departmentRepository)
        {
            _userManager = usrMgr;
            _roleManager = roleMgr;
            _passwordHasher = passwordHash;
            //_emailSender = emailSender;
            _context = context;
            _branchRepository = branchRepository;
            _departmentRepository = departmentRepository;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList()
                .Select(user => new UserViewModel
                {
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    Id = user.Id,
                    Roles = string.Join(",", _userManager.GetRolesAsync(user).Result),
                    BranchName = _branchRepository.GetById(user.BranchId.Value).Result.Name,
                    DepartmentName = _departmentRepository.GetById(user.DepartmentId.Value).Result.Name,
                }).ToList();
            return View(users);
        }

        public async Task<ViewResult> Create()
        {
            ViewData["Roles"] = new SelectList(_roleManager.Roles, "NormalizedName", "Name");
            ViewData["BranchId"] = new SelectList(await _branchRepository.GetAll(), "Id", "Name");
            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserModel user)
        {
            if (ModelState.IsValid)
            {
                var appUser = new Users
                {
                    UserName = user.Email,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    PhoneNumber = user.PhoneNumber,
                    LastName = user.LastName,
                    FullName = user.FirstName + " " + user.LastName,
                    EmailConfirmed = true,
                    BranchId = user.BranchId,
                    DepartmentId = user.DepartmentId,
                };

                var result = await _userManager.CreateAsync(appUser, user.Password);
                if (result.Succeeded)
                {
                    var addResult = await _userManager.AddToRoleAsync(appUser, user.Roles);
                    foreach (var error in addResult.Errors)
                        ModelState.AddModelError("", error.Description);
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }

            ViewData["Roles"] = new SelectList(_roleManager.Roles, "NormalizedName", "Name", user.Roles);
            ViewData["BranchId"] = new SelectList(await _branchRepository.GetAll(), "Id", "Name", user.BranchId);
            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.GetAll(), "Id", "Name", user.DepartmentId);
            return View(user);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return RedirectToAction(nameof(Index));
            var userView = new UserModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id
            };
            var userRole = await _userManager.GetRolesAsync(user);

            ViewData["Roles"] = new SelectList(_roleManager.Roles, "NormalizedName", "Name", userRole.FirstOrDefault());
            ViewData["BranchId"] = new SelectList(await _branchRepository.GetAll(), "Id", "Name", user.BranchId);
            ViewData["DepartmentId"] = new SelectList(await _departmentRepository.GetAll(), "Id", "Name", user.DepartmentId);
            return View(userView);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user != null)
            {
                user.BranchId = model.BranchId;
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.FullName = model.FirstName + " " + model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.EmailConfirmed = true;
                user.BranchId = model.BranchId;
                user.DepartmentId = model.DepartmentId;

                var result = await _userManager.UpdateAsync(user);
                var roles = await _userManager.GetRolesAsync(user);
                var remove = await _userManager.RemoveFromRolesAsync(user, roles);
                var role = _roleManager.FindByNameAsync(model.Roles).Result;
                var add = await _userManager.AddToRoleAsync(user, role.Name);


                if (result.Succeeded)
                    return RedirectToAction("Index");
                Errors(result);
            }
            else
            {
                ModelState.AddModelError("", "User Not Found");
            }

            return View(model);
        }

        private void Errors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }
    }
}
