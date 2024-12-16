using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string? FullName { get; set; }

    public string? Position { get; set; } 
    public string? image { get; set; } 
    public string? Phone { get; set; } 

    public string? Email { get; set; }
    public bool? IsActive { get; set; }
    public DateOnly HireDate { get; set; }

    public int? RestaurantId { get; set; }

    public virtual Restaurant? Restaurant { get; set; }
}
