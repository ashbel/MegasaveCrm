using Megasave.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Megasave.Domain.Identity
{
    public class RoleEdit
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<Users> Members { get; set; }
        public IEnumerable<Users> NonMembers { get; set; }
    }
}