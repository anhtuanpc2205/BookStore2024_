using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class ViewOrderDetail
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string? ShippingAddress { get; set; }

    public decimal TotalAmount { get; set; }

    public int OrderDetailId { get; set; }

    public int BookDetailId { get; set; }

    public int Quantity { get; set; }

    public string BookTitle { get; set; } = null!;

    public string? BookImageUrl { get; set; }

    public string FormatName { get; set; } = null!;

    public string UserName { get; set; } = null!;
}
