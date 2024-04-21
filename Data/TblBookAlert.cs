namespace BookStore2024.Data
{
    public class TblBookAlert
    {
        public int alertId { get; set; }
        public int BookDetailId { get; set; }
        public string? HomeBannerImageUrl { get; set; }
        public string? ProductsBannerImageUrl { get; set; }
        public virtual TblBookDetail BookDetail { get; set; } = null!;
    }
}
