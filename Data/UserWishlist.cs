using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class UserWishlist
{
    public int UserId { get; set; }

    public int BookDetailId { get; set; }

    public string BookTitle { get; set; } = null!;

    public string? BookImageUrl { get; set; }

    public string FormatName { get; set; } = null!;
}
