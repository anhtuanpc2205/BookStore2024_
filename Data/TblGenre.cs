using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblGenre
{
    public int GenreId { get; set; }

    public string GenreName { get; set; } = null!;

    public virtual ICollection<TblBook> TblBooks { get; set; } = new List<TblBook>();
}
