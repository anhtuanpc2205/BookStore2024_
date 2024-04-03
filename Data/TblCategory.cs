using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<TblBook> TblBooks { get; set; } = new List<TblBook>();
}
