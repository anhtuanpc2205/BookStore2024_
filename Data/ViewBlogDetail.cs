using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class ViewBlogDetail
{
    public int BlogId { get; set; }

    public string BlogTitle { get; set; } = null!;

    public string? BlogDescription { get; set; }

    public string? BlogContent { get; set; }

    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public string? ImgUrl { get; set; }

    public int? Views { get; set; }
}
