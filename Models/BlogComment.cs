using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class BlogComment
{
    public int CommentId { get; set; }

    public string? Name { get; set; }

    public string? Alias { get; set; }
    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Detail { get; set; }
    public DateTime? CreatedDate { get; set; }
    public int? BlogId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Blog? Blog { get; set; }
}
