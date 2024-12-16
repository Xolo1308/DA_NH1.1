using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class Promotion
{
    public int PromotionId { get; set; }

    public string Code { get; set; } = null!;

    public string? Description { get; set; }

    public decimal DiscountAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }
}
