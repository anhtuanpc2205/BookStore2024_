using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblBookDetail
{
    public int BookDetailId { get; set; }

    public int BookId { get; set; }

    public string? Isbn10 { get; set; }

    public string? Isbn13 { get; set; }

    public int FormatId { get; set; }

    public int StockQuantity { get; set; }

    public int? Views { get; set; }

    public decimal Price { get; set; }

    public decimal? Discount { get; set; }

    public virtual TblBook Book { get; set; } = null!;

    public virtual TblFormat Format { get; set; } = null!;

    public virtual ICollection<TblBookAlert> TblBookAlerts { get; set; } = new List<TblBookAlert>();

    public virtual ICollection<TblNewReleaseBook> TblNewReleaseBooks { get; set; } = new List<TblNewReleaseBook>();

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual ICollection<TblUserWishlist> TblUserWishlists { get; set; } = new List<TblUserWishlist>();
}
