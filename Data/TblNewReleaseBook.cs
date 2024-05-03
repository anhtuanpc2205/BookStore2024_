using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblNewReleaseBook
{
    public int NewReleaseId { get; set; }

    public int? BookDetailId { get; set; }

    public virtual TblBookDetail? BookDetail { get; set; }
}
