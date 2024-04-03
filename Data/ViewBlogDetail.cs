namespace BookStore2024.Data
{
    public class ViewBlogDetail
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; } = null!;
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public string? BlogImageUrl { get; set; }
        public string? BlogDescription { get; set; }
        public int? Views { get; set; }
        public string BlogContent { get; set; } = string.Empty!;

    }
}
