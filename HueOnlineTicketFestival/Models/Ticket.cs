using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public int CustomerId { get; set; }

    public int UserId { get; set; }

    public int LocationId { get; set; }

    public int EventId { get; set; }

    public int TicketTypeId { get; set; }

    public string TicketName { get; set; } = null!;

    public bool? Status { get; set; }

    public int? Price { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual EventsLocation EventsLocation { get; set; } = null!;

    public virtual ICollection<TicketCheckin> TicketCheckins { get; set; } = new List<TicketCheckin>();

    public virtual TicketType TicketType { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
