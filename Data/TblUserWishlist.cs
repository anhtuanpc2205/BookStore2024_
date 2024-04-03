using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblUserWishlist
{
    public int WishlistId { get; set; }

    public int UserId { get; set; }

    public int BookDetailId { get; set; }

    public virtual TblBookDetail BookDetail { get; set; } = null!;

    public virtual TblUser User { get; set; } = null!;
}
