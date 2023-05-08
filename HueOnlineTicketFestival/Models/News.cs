using System;
using System.Collections.Generic;

namespace HueOnlineTicketFestival.Models;

public partial class News
{
    public int NewsId { get; set; }

    public int EventId { get; set; }

    public string? NewName { get; set; }

    public string? NewsContent { get; set; }

    public DateTime? CreateAt { get; set; }

    public DateTime? UpdateAt { get; set; }

    public virtual Event Event { get; set; } = null!;
}
