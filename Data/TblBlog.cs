using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblBlog
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string? BlogDescription { get; set; }

    public string? Content { get; set; }

    public int AuthorId { get; set; }

    public string? ImgUrl { get; set; }

    public int? Views { get; set; }

    public virtual TblAuthor Author { get; set; } = null!;
}
