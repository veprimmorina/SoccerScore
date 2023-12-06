using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace SpecFlowZdt.Support
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirmation Password is required")]
        public string? ConfirmationPassword { get; set; }
    }
}
