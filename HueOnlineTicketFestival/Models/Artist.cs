using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class Artist
{
    public int ArtistId { get; set; }

    public string? ArtistName { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
