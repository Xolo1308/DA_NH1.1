using System;
using System.Collections.Generic;

namespace DA_NH.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? CustomerId { get; set; }

    public int? RestaurantId { get; set; }

    public DateTime ReservationDate { get; set; }

    public int NumberOfGuests { get; set; }

    public string? SpecialRequests { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual Restaurant? Restaurant { get; set; }
}
