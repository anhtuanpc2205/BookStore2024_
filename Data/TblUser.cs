using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? UserAddress { get; set; }

    public byte Role { get; set; }

    public string? ProfileImageUrl { get; set; }

    public virtual ICollection<TblOrder> TblOrders { get; set; } = new List<TblOrder>();

    public virtual ICollection<TblUserWishlist> TblUserWishlists { get; set; } = new List<TblUserWishlist>();
}
