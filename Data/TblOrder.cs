using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblOrder
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string OrderStatus { get; set; } = null!;

    public string? ShippingMethod { get; set; }

    public byte PaymentMethod { get; set; }

    public decimal? ShippingFee { get; set; }

    public virtual ICollection<TblOrderDetail> TblOrderDetails { get; set; } = new List<TblOrderDetail>();

    public virtual TblUser User { get; set; } = null!;
}
