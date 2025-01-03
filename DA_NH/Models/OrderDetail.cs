﻿using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? MenuItemId { get; set; }

    public int Quantity { get; set; }

    public int UnitPrice { get; set; }

    public int? Discount { get; set; }

    public virtual MenuItem? MenuItem { get; set; }

    public virtual Order? Order { get; set; }
}
