using BookStore2024.Data;

namespace BookStore2024.ViewModels
{
    public class BlogVM
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; } = null!;
        public string? BlogDescription { get; set; }
        public string? Content { get; set; }
        public int AuthorId { get; set; }
        public string? ImgUrl { get; set; }
        public int? Views { get; set; }
        public string AuthorName { get; set; } = null!;
    }
}
