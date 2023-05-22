using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using HueOnlineTicketFestival.data;
using HueOnlineTicketFestival.Models;
using HueOnlineTicketFestival.Prototypes;
using HueOnlineTicketFestival.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> BuyTicket(string email)
        {
            var newEmail = new EmailDTO
            {
                Subject = "Buy event ticket success",
                To = email,
                Body = "QR ticket"
            };
            string text = "Hello, QR Code!";
            Bitmap qrCodeImage = ImageHelper.GenerateQRCode(text);
            string imagesFolderPath = Path.Combine(_hostingEnvironment.ContentRootPath, "public\\images");


            qrCodeImage.Save(imagesFolderPath, System.Drawing.Imaging.ImageFormat.Png);


            return Ok();
        }
    }
}