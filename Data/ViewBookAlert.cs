namespace BookStore2024.Data
{
    public class ViewBookAlert
    {
        public int BookDetailId { get; set; }
        public string BookTitle { get; set; } = null!;
        public string? BookImageUrl { get; set; }
        public string AuthorName { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
    }
}
