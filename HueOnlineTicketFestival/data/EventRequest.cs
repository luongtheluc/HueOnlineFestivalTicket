using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueOnlineTicketFestival.data
{
    public class EventRequest
    {
        public int EventId { get; set; }

        public int EventTypeId { get; set; }

        public string? EventName { get; set; }

        public string? EventContent { get; set; }

        public DateTime? CreateAt { get; set; }

        public DateTime? UpdateAt { get; set; }
    }
}