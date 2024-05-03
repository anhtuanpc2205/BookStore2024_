using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class TblAuthor
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public string? AuthorDescription { get; set; }

    public string? ProfileImageUrl { get; set; }

    public virtual ICollection<TblBlog> TblBlogs { get; set; } = new List<TblBlog>();

    public virtual ICollection<TblBook> TblBooks { get; set; } = new List<TblBook>();
}
