using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblFormat
{
    public int FormatId { get; set; }

    public string FormatName { get; set; } = null!;

    public virtual ICollection<TblBookDetail> TblBookDetails { get; set; } = new List<TblBookDetail>();
}
