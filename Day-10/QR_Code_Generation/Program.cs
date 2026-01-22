using QRCoder;
using System;
using System.IO;

namespace QR_Code_Generation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string qText = "https://www.formula1.com/";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qText, QRCodeGenerator.ECCLevel.Q);

            PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
            byte[] qrCodeBytes = qrCode.GetGraphic(20);

            File.WriteAllBytes("F1QRCode.png", qrCodeBytes);

            Console.WriteLine("QR Code generated and saved as F1QRCode.png");
        }
    }
}
