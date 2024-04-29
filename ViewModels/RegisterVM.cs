using System.ComponentModel.DataAnnotations;

namespace BookStore2024.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Enter your name")]
        [MaxLength(50,ErrorMessage = "maximum is 50 characters.")]
        public string UserName { get; set; } = "";


        [Required(ErrorMessage = "Enter your email address")]
        [MaxLength(100, ErrorMessage = "maximum is 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "Enter your password")]
        [MaxLength(20, ErrorMessage = "maximum is 20 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";
        
        public string? ShippingAddress { get; set; }

        public byte Role { get; set; } = 2;

        public string? ProfileImageUrl { get; set; }
    }
}
