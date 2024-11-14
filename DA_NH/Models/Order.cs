using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int? CustomerId { get; set; }

    public int TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public string? Note { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
