using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HueOnlineTicketFestival.data;

namespace HueOnlineTicketFestival.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailDTO request, string filepath = null!);
    }
}