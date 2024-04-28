using System.ComponentModel.DataAnnotations;

namespace BookStore2024.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="*")]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Enter username,Email and Password")]
        [MaxLength(50,ErrorMessage = "maximum is 50 characters.")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Enter username,Email and Password")]
        [MaxLength(100, ErrorMessage = "maximum is 100 characters.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter username,Email and Password")]
        [MaxLength(20, ErrorMessage = "maximum is 20 characters.")]
        public string Password { get; set; }
        
        public string? ShippingAddress { get; set; }

        public byte Role { get; set; } = 2;

        public string? ProfileImageUrl { get; set; }
    }
}
