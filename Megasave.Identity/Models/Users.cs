using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Megasave.Domain.Entities;

namespace Megasave.Identity.Models
{
    public class Users : IdentityUser
    {
        [PersonalData]
        [DisplayName("Name")]
        public string FirstName { get; set; }

        [PersonalData]
        [DisplayName("Surname")]
        public string LastName { get; set; }

        [PersonalData]
        [DisplayName("Name")]
        public string FullName { get; set; }

        [Display(Name = "Branch")]
        public Guid? BranchId { get; set; }

        [Display(Name = "Department")]
        public Guid? DepartmentId { get; set; }

        public Branches Branch { get; set; }
        public Departments Department { get; set; }
    }
}