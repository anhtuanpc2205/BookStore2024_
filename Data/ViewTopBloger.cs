using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class ViewTopBloger
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public string? ProfileImageUrl { get; set; }

    public int? NumBlogs { get; set; }
}
