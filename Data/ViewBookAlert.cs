using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class ViewBookAlert
{
    public int BookDetailId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string? BookImageUrl { get; set; }

    public string AuthorName { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public string? ImgHomeBanner { get; set; }

    public string? ImgProductsBanner { get; set; }
}
