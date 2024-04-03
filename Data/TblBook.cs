using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblBook
{
    public int BookId { get; set; }

    public string BookTitle { get; set; } = null!;

    public int AuthorId { get; set; }

    public string? BookImageUrl { get; set; }

    public string? BookDescription { get; set; }

    public string? Publisher { get; set; }

    public string? Language { get; set; }

    public string? IllustrationsNote { get; set; }

    public int? Pages { get; set; }

    public int GenreId { get; set; }

    public int CategoryId { get; set; }

    public virtual TblAuthor Author { get; set; } = null!;

    public virtual TblCategory Category { get; set; } = null!;

    public virtual TblGenre Genre { get; set; } = null!;

    public virtual ICollection<TblBookDetail> TblBookDetails { get; set; } = new List<TblBookDetail>();
}
