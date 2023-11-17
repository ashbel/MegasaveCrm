using System.ComponentModel.DataAnnotations;

namespace Megasave.Domain.Identity
{
    public class UserModel
    {
        [Required]

        [Display(Name = "Name")]
        public string FirstName { get; set; }

        [Required]

        [Display(Name = "Surname")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Roles")]
        public string Roles { get; set; }

        [Display(Name = "Branch")]
        public Guid BranchId { get; set; }

        [Display(Name = "Department")]
        public Guid DepartmentId { get; set; }

        public string Id { get; set; }
    }
}