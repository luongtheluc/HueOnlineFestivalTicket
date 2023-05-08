using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class EventsLocation
{
    public int LocationId { get; set; }

    public int EventId { get; set; }

    public int? TicketQuantity { get; set; }

    public DateTime? StartAt { get; set; }

    public DateTime? EndAt { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
