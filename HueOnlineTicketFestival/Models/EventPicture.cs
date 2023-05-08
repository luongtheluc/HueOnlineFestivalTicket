using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class EventPicture
{
    public int EventImageId { get; set; }

    public string? EventImageName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
