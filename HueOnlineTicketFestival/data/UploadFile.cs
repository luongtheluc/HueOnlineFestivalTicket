using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HueOnlineTicketFestival.data
{
    public class UploadFile
    {
        public int Id { get; set; }
        public IFormFile? Files { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}