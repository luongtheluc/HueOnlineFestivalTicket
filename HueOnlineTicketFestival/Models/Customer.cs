using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Name { get; set; }

    public DateTime? Birthday { get; set; }

    public string? IdentityCardNumber { get; set; }

    public string? PaymentInfo { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
