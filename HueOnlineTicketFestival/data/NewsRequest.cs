using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueOnlineTicketFestival.data
{
    public class NewsRequest
    {
        public int NewsId { get; set; }

        public int EventId { get; set; }

        public string? NewName { get; set; }

        public string? NewsContent { get; set; }

    }
}