namespace BookStore2024.ViewModels
{
	public class ProductVM
	{
        public int BookDetailId { get; set; }
        public string? ProductName { get; set; }
        public int GenreId { get; set; }
        public string? GenreName { get; set; } = null!;
        public string? CategoryName { get; set; } = null!;
        public int CategoryId { get; set; }
        public decimal? Price { get; set; }
		public decimal? Discount { get; set; } = 0;
        public string? Publisher { get; set; }
        public string? ProductImg { get; set; }
        public string? ProductDescription { get; set; }
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? Language { get; set; }
        public int? Pages { get; set; }
        public string? IllustrationsNote { get; set; }
        public string? Isbn10 { get; set; }
        public string? Isbn13 { get; set; }
        public int FormatId { get; set; } = 1;
        public string? FormatName { get; set; } = null!;
        public int? StockQuantity { get; set; }
        public int? Views { get; set; }
        public int BookId { get; set; }

        public int Sold { get; set; } = 0;

    }
}
