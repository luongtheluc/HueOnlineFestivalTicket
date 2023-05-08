using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? LocationName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<EventsLocation> EventsLocations { get; set; } = new List<EventsLocation>();
}
