namespace BookStore2024.ViewModels
{
    public class TopBlogersVM
    {
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public int NumbersOfPost {  get; set; } 
        public string AuthorImgURL { get; set; } = null!;
    }
}
