using System.ComponentModel.DataAnnotations;

namespace BookStore2024.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Enter your email address")]
        [MaxLength(255, ErrorMessage = "maximum is 255 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "Enter your password")]
        [MaxLength(255, ErrorMessage = "maximum is 255 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
    }
}
