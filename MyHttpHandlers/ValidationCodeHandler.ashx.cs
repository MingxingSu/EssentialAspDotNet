using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.SessionState;
namespace MyHttpHandlers
{
    /// <summary>
    /// Summary description for ValidationCodeHandler
    /// </summary>
    public class ValidationCodeHandler : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "image/jpg";

            Image image = new Bitmap(60, 30);
            int code = new Random().Next(1000, 10000);
            string codeString = code.ToString();

            context.Session["ValidationCode"] = codeString;

            using (var g = Graphics.FromImage(image)) 
            {
                g.Clear(Color.WhiteSmoke);

                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;

                g.DrawString(codeString,
                    new Font("Arial", 14),
                    Brushes.Blue,
                    new Rectangle(0, 0, image.Width, image.Height),
                format);
            }

            context.Response.ContentType = "image/jpg";

            image.Save(context.Response.OutputStream,
                System.Drawing.Imaging.ImageFormat.Jpeg);

            context.Response.End();

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}