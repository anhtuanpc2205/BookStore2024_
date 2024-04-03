namespace BookStore2024.ViewModels
{
    public class CartItem
    {
        public int BookDetailId { get; set; }
        public string? ProductName { get; set; } = null;
        public string? ProductImg { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
        public decimal Amount => Price * Quantity;
    }
}
