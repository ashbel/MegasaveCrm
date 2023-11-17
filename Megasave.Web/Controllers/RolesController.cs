using Megasave.Web.Models.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Megasave.Identity.Models;

namespace Megasave.Web.Controllers
{
    [Authorize]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;

        public RolesController(RoleManager<IdentityRole> roleMgr, UserManager<Users> userMrg)
        {
            _roleManager = roleMgr;
            _userManager = userMrg;
        }
        public ViewResult Index() => View(_roleManager.Roles);

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            return View(name);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<Users>();
            var nonMembers = new List<Users>();
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                    members.Add(user);
                else
                    nonMembers.Add(user);
            }
            return View(new RoleEdit
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    Users user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                        if (!result.Succeeded)
                            Errors(result);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Edit(model.RoleId);
        }

        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }
    }
}
