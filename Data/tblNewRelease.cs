namespace BookStore2024.Data
{
    public class tblNewRelease
    {
        public int newReleaseID { get; set; }
        public int BookDetailId { get; set; }
        public virtual TblBookDetail BookDetail { get; set; } = null!;
    }
}
