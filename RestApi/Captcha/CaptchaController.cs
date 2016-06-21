using SRVTextToImage;
using System.Drawing;
using System.Web.Http;
using System.IO;
using CFSE.RestApi.GenericRest;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using CFSE.Common.SecurityEncryption;

namespace CFSE.RestApi.Captcha
{
    public class CaptchaController : GenericApiController
    {
        [HttpGet]
        [Route("api/v1/captcha")]
        public HttpResponseMessage Get()
        {
            MemoryStream bitmapStream = new MemoryStream();
            CaptchaRandomImage CI = new CaptchaRandomImage();

            string captchaText = CI.GetRandomString(5);

            string cTextEncrypted = Encryption.Encrypt(captchaText);

            CI.GenerateImage(captchaText, 200, 50, Color.DarkGray, Color.White);
            CI.Image.Save(bitmapStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            CI.Dispose();

            bitmapStream.Position = 0;

            HttpResponseMessage responseMessage = new HttpResponseMessage(HttpStatusCode.OK);
            responseMessage.Content = new StreamContent(bitmapStream);
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
            responseMessage.Content.Headers.ContentLength = bitmapStream.Length;
            responseMessage.Headers.Add("captcha-key", cTextEncrypted);

            return responseMessage;
        }
    }
}