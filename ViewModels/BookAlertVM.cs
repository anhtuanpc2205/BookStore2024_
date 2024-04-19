namespace BookStore2024.ViewModels
{
    public class BookAlertVM
    {
        public string BookTitle { get; set; } = null!;
        public int BookDetailId { get; set; }
        public string? HomeBannerImageUrl { get; set; }
        public string? ProductsBannerImageUrl { get; set; }
        public string AuthorName { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public int? PageNumber { get; set; }
    }
}
