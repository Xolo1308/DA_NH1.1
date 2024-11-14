using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class MenuReview
{
    public int ProductReviewId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Detail { get; set; }

    public int? MenuItem { get; set; }

    public bool? IsActive { get; set; }

    public virtual MenuItem? MenuItemNavigation { get; set; }
}
