using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class TicketCheckin
{
    public int TicketCheckinId { get; set; }

    public int TicketId { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Ticket Ticket { get; set; } = null!;
}
