using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueOnlineTicketFestival.data
{
    public class TicketDto
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


    }
}