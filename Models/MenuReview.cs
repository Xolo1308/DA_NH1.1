using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class MenuReview
{
    public int ProductReviewId { get; set; }

    public string? Name { get; set; }

    public string? Alias { get; set; }
    public string? Description { get; set; }
    public string? Image {  get; set; }

    public string? Phone { get; set; }
    public string? Position { get; set; }

    public string? Email { get; set; }

    public int? MenuItem { get; set; }
    public int? star {  get; set; }
    public DateTime? CreateDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual MenuItem? MenuItemNavigation { get; set; }
}
