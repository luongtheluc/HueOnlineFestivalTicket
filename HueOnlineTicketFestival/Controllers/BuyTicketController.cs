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

namespace HueOnlineTicketFestival.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuyTicketController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly ITicketService _ticketService;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public BuyTicketController(IEmailService emailService, ITicketService ticketService, IWebHostEnvironment hostingEnvironment)
        {
            this._ticketService = ticketService;
            this._emailService = emailService;
            _hostingEnvironment = hostingEnvironment;


        }
        [HttpPost]
        public async Task<IActionResult> BuyTicket(string email, int id)
        {
            var newEmail = new EmailDTO
            {
                Subject = "Buy event ticket success",
                To = email,
                Body = "<h1>Đây là QR vé của bạn</h1><br><br><br><p>Sử dụng để checkin khi vào cổng</p>"
            };
            string publicPath = _hostingEnvironment.WebRootPath;
            string qrFolderPath = Path.Combine(publicPath, "QR");
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(id.ToString(), QRCodeGenerator.ECCLevel.Q);
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