using System.ComponentModel.DataAnnotations;

namespace OtherPerspectivesWebApp.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress, MaxLength(500)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password does not match!")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}