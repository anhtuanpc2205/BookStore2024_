namespace BookStore2024.Data
{
    public class ViewBestSelling
    {
        public int BookId { get; set; }
        public int BookDetailId { get; set; }
        public string BookTitle { get; set; } = null!;
        public int AuthorId { get; set; }
        public string AuthorName { get; set; } = null!;
        public string? AuthorDescription { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? BookImageUrl { get; set; }
        public string? BookDescription { get; set; }
        public string? Publisher { get; set; }
        public string? Language { get; set; }
        public string? IllustrationsNote { get; set; }
        public int? Pages { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; } = null!;
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Isbn10 { get; set; }
        public string? Isbn13 { get; set; }
        public int FormatId { get; set; }
        public string FormatName { get; set; } = null!;
        public int StockQuantity { get; set; }
        public int? Views { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; } = 0;
        public int TotalQuantitySold { get; set; }
    }
}
