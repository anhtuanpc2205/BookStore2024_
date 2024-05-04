using System.ComponentModel.DataAnnotations;

namespace BookStore2024.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Enter your name!")]
        [MaxLength(255,ErrorMessage = "maximum is 255 characters.")]
        public string UserName { get; set; } = "";


        [Required(ErrorMessage = "Enter your email address")]
        [MaxLength(255, ErrorMessage = "maximum is 255 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = "";


        [Required(ErrorMessage = "Enter your password")]
        [MaxLength(255, ErrorMessage = "maximum is 255 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Enter your address")]
        [MaxLength(255, ErrorMessage = "maximum is 255 characters.")]
        public string UserAddress { get; set; } = "";

        public byte Role { get; set; } = 2;

        //public string? ProfileImageUrl { get; set; }
    }
}
