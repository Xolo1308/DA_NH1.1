using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? Description { get; set; }

    public int? Position { get; set; }

    public virtual ICollection<Blog> Blogs { get; set; } = new List<Blog>();
}
