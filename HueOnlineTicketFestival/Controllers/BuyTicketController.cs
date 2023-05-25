using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;
using HueOnlineTicketFestival.data;
using HueOnlineTicketFestival.Models;
using HueOnlineTicketFestival.Prototypes;
using HueOnlineTicketFestival.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.IO;

namespace HueOnlineTicketFestival.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyTicketController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ITicketService _ticketService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IUserService _userService;
        private readonly IEventService _eventService;
        private readonly ILocationService _locationService;

        public BuyTicketController(ILocationService locationService, IEmailService emailService, ITicketService ticketService, IWebHostEnvironment hostingEnvironment, IUserService userService, IEventService eventService)
        {
            this._locationService = locationService;
            this._eventService = eventService;
            this._userService = userService;
            this._ticketService = ticketService;
            this._emailService = emailService;
            _hostingEnvironment = hostingEnvironment;


        }
        [HttpPost]
        public async Task<IActionResult> BuyTicket(string email, TicketDto ticket)
        {
            var user = await _userService.GetUserByIdAsync(ticket.UserId);
            var events = await _eventService.GetEventByIdAsync(ticket.EventId);
            var location = await _locationService.GetLocationByIdAsync(ticket.LocationId);
            var newEmail = new EmailDTO
            {
                Subject = "Buy event ticket success",
                To = email,
                Body = "<h1>Đặt vé thành công</h1>"
                + "<br><p>Xin chào " + user.Name
                + " chúc mừng bạn đã đặt vé tham dự sự kiện " + events.EventName + " được diễn ra tại " + location.LocationName + " thành công </p>"
                + "<p>Dưới đây là mã QR dùng để checkin khi vào cổng</p>"
            };
            string publicPath = _hostingEnvironment.WebRootPath;
            string qrFolderPath = Path.Combine(publicPath, "QR");
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticket.ToString(), QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);

            using (Bitmap bitmap = qrCode.GetGraphic(20))
            {
                string qrFilePath = Path.Combine(qrFolderPath, "qr_code_" + Guid.NewGuid() + ".png");

                bitmap.Save(qrFilePath, ImageFormat.Png);
                await _emailService.SendEmailAsync(newEmail, qrFilePath);

            }
            return Ok();
        }
    }
}