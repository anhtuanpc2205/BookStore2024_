namespace BookStore2024.Data
{
    public class ViewNewReleaseBooks
    {
        public int BookDetailId { get; set; }
        public string BookTitle { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public string? BookImageUrl { get; set; }
        public string? BookDescription { get; set; }
        public string GenreName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string FormatName { get; set; } = null!;
    }
}
