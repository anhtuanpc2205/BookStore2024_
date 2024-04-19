namespace BookStore2024.Data
{
    public class ViewBookAlert
    {
        public int BookDetailId { get; set; }
        public string BookTitle { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? Discount { get; set; }
        public string? HomeBannerImageUrl { get; set; }
        public string? ProductsBannerImageUrl { get; set; }
    }
}
