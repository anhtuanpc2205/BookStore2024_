using System;
using System.Collections.Generic;

namespace BookStore2024.Data;

public partial class ViewAuthorDetail
{
    public int AuthorId { get; set; }

    public string AuthorName { get; set; } = null!;

    public string? AuthorDescription { get; set; }

    public string? ProfileImageUrl { get; set; }

    public int? PublishedBooks { get; set; }
}
