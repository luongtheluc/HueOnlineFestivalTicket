using QRCoder;
using System.Drawing;

namespace HueOnlineTicketFestival.Prototypes
{
    public class ImageHelper
    {
        public static Bitmap GenerateQRCode(string text)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(text, QRCodeGenerator.ECCLevel.Q);
            var qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(10);

            return qrCodeImage;
        }

    }
}