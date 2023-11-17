using Megasave.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Megasave.Domain.Identity.ViewModels
{
    public class UserViewModel : Users
    {
        [PersonalData]
        public string FullName { get; set; }

        [PersonalData]
        public string Roles { get; set; }

        public string BranchName { get; set; }

        public string DepartmentName { get; set; }
    }
}