using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblOrderDetail
{
    public int OrderDetailId { get; set; }

    public int OrderId { get; set; }

    public int BookDetailId { get; set; }

    public int Quantity { get; set; }

    public virtual TblBookDetail BookDetail { get; set; } = null!;

    public virtual TblOrder Order { get; set; } = null!;
}
