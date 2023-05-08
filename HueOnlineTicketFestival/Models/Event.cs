using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class Event
{
    public int EventId { get; set; }

    public int EventTypeId { get; set; }

    public string? EventName { get; set; }

    public string? EventContent { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual EventType EventType { get; set; } = null!;

    public virtual ICollection<EventsLocation> EventsLocations { get; set; } = new List<EventsLocation>();

    public virtual ICollection<News> News { get; set; } = new List<News>();

    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();

    public virtual ICollection<EventPicture> EventImages { get; set; } = new List<EventPicture>();
}
