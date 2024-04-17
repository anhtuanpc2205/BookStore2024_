namespace BookStore2024.ViewModels
{
    public class RegisterVM
    {
        
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string? ShippingAddress { get; set; }

        public byte Role { get; set; }

        public string? ProfileImageUrl { get; set; }
    }
}
