using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using Megasave.Identity;
using Megasave.Identity.Models;

namespace Megasave.Web.Claims
{
    public class CustomClaimsFactory : UserClaimsPrincipalFactory<Users, IdentityRole>
    {
        private readonly MopaneIdentityDbContext _context;
        public CustomClaimsFactory(
            UserManager<Users> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<IdentityOptions> optionsAccessor,
            MopaneIdentityDbContext context)
            : base(userManager, roleManager, optionsAccessor)
        {
            _context = context;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Users user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("uid", user.Id));
            identity.AddClaim(new Claim("username", user.UserName));
            //var branch = _context.Branches.FirstOrDefault(c => c.Id == user.BranchId)?.Name;
            //identity.AddClaim(new Claim("Branch", branch ?? "No Branch"));

            var roles = await UserManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }

            return identity;
        }

        // This method is called only when login. It means that "the drawback   
        // of calling the database with each HTTP request" never happen.  
        public override async Task<ClaimsPrincipal> CreateAsync(Users user)
        {
            var principal = await base.CreateAsync(user);

            if (!string.IsNullOrEmpty(user.Id))
            {
                ((ClaimsIdentity)principal.Identity)?.AddClaims(
                    new[]
                    {
                    new Claim("uid", user.Id) ,
                    new Claim("username",user.UserName)
                    });
            }

            return principal;
        }
    }
}