using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class MenuItem
{
    public int MenuItemId { get; set; }

    public string Name { get; set; } = null!;

    public string? Detail { get; set; }

    public string? Description { get; set; }

    public int Price { get; set; }

    public string? ImageUrl { get; set; }

    public int? Quantity { get; set; }

    public bool IsAvailable { get; set; }

    public int? CategoryId { get; set; }

    public bool? IsNew { get; set; }

    public int? RestaurantId { get; set; }

    public virtual MenuCategory? Category { get; set; }

    public virtual ICollection<MenuReview> MenuReviews { get; set; } = new List<MenuReview>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Restaurant? Restaurant { get; set; }
}
