namespace BookStore2024.ViewModels
{
    public class BookAlertVM
    {
        public string BookTitle { get; set; } = null!;
        public int BookDetailId { get; set; }
        public string? BookImageUrl { get; set; }
        public string AuthorName { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
    }
}
