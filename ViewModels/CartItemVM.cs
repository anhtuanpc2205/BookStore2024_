namespace BookStore2024.ViewModels
{
    public class CartItemVM
    {
        public int BookDetailId { get; set; }
        public string? ProductName { get; set; } = null;
        public string? ProductImg { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
		public int FormatId { get; set; } = 1;
		public string FormatName { get; set; } = null!;
		public decimal Amount => Price * Quantity;
    }
}
