using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;
using Titan.Model.DataModel;
using Titan.Blog.AppService.DomainService;

namespace Titan.Blog.WebAPP.Controllers
{
    [CustomRoute]
    [Authorize("Permission")]
    public class ImageTestController : ApiControllerBase
    {
        //构造函数注入上下文
        private readonly AuthorDomainSvc _authorSvc;
        public ImageTestController(AuthorDomainSvc authorSvc)
        {
            _authorSvc = authorSvc;
        }

        [Produces("image/png")]//Swagger可以根据这个来自动选择请求类型
        [HttpGet("GetImage/{id}",Name = "GetImage")]
        public HttpResponseMessage Get(string id)
        {
            var response = new HttpResponseMessage();
            response.Content = ImageStream(Color.Red, Color.Cyan);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            return response;
        }

        /// <remarks>
        /// <h2>Testing html table</h2>
        /// <table border="1">
        ///     <tr>
        ///         <td colspan="3"><span class="method">ONE</span></td>
        ///     </tr>
        ///     <tr>
        ///         <td>ABC11</td>
        ///         <td>ABC22</td>
        ///         <td>ABC33</td>
        ///     </tr>
        /// </table>
        /// <img src="https://yuml.me/diagram/class/%5BSupplier%7Bbg:orange%7D%5D,%5BSupplier%5D-0..1%3E%5BAddress%5D,%5BSupplier%5D" />
        /// <img src="data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==" alt="Red dot" />
        /// </remarks>
        [Produces("application/json")]//Swagger可以根据这个来自动选择请求类型
        [HttpPost("EFCoreTest", Name = "EFCoreTest")]
        public OpResult<List<Author>> EFCoreTest(string id)
        {
            //ModelBaseContext fds = new ModelBaseContext(new DbContextOptions<ModelBaseContext>());
            //AuthorDomainSvc _authorSvc = new AuthorDomainSvc();
            //var employee = _authorSvc.GetList();
            //var data = _authorSvc.SqlTest();
            //var ok = _authorSvc.CommandSql();
            //var employee = new List<Author>();
            return new OpResult<List<Author>>(OpResultType.Success, "", new List<Author>());

            //using (var tran = _context.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        _context.ClassTable.Add(new ClassTable { ClassName = "AAAAA", ClassLevel = 2 });
            //        _context.ClassTable.Add(new ClassTable { ClassName = "BBBBB", ClassLevel = 2 });
            //        _context.SaveChanges();
            //        throw new Exception("模拟异常");
            //        tran.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        tran.Rollback();
            //        // TODO: Handle failure
            //    }
            //}
        }

        //public (bool, object) gettest()
        //{
        //    return (true, 1);
        //}

        //// POST: api/Image
        //[SwaggerResponse(200, mediaType: "image/png")]
        //public HttpResponseMessage Post(ImageData img)
        //{
        //    var response = new HttpResponseMessage();
        //    if (img == null || string.IsNullOrEmpty(img.Data) || !img.Data.StartsWith("data"))
        //        response.Content = ImageStream(Color.White, Color.Blue);
        //    else
        //    {
        //        response.Content = ImageStream(img.Data);
        //        MemoryCache.Default.Remove("image_data");
        //        var policy = new CacheItemPolicy { SlidingExpiration = TimeSpan.FromMinutes(2) };
        //        MemoryCache.Default.Add("image_data", img.Data, policy);
        //    }

        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");
        //    return response;
        //}

        //// PUT: api/Image
        //[SwaggerResponse(200, "Download an image", mediaType: "application/octet-stream")]
        //public HttpResponseMessage Put()
        //{
        //    var response = new HttpResponseMessage();
        //    var c = RandomColor;
        //    response.Content = ImageStream(Color.White, c);
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        //    response.Content.Headers.ContentDisposition =
        //        new ContentDispositionHeaderValue("attachment") { FileName = $"image_{c.R}_{c.G}_{c.B}.png" };
        //    return response;
        //}

        //// PATCH: api/Image
        //[SwaggerResponse(200, "image.svg", mediaType: "image/svg")]
        //public HttpResponseMessage Patch()
        //{
        //    var response = new HttpResponseMessage();
        //    response.Content = new StringContent(
        //        "<svg><circle cx='50' cy='50' r='40' fill='red' /></svg>",
        //        Encoding.UTF8, "text/html"
        //    );
        //    response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/svg");
        //    return response;
        //}

        #region 公共
        private static Random rnd = new Random();

        internal Color RandomColor
        {
            get
            {
                return Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            }
        }

        private string FixBase64ForImage(string Image)
        {
            var sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", String.Empty);
            sbText.Replace(" ", String.Empty);
            sbText.Replace("data:image/jpeg;base64,", String.Empty);
            return sbText.ToString();
        }

        internal StreamContent ImageStream(string data)
        {
            Byte[] bitmapData = Convert.FromBase64String(FixBase64ForImage(data));
            System.IO.MemoryStream streamBitmap = new System.IO.MemoryStream(bitmapData);
            Bitmap bitImage = new Bitmap((Bitmap)Image.FromStream(streamBitmap));

            var memStream = new MemoryStream();
            bitImage.Save(memStream, ImageFormat.Png);
            memStream.Position = 0;
            return new StreamContent(memStream);
        }

        internal StreamContent ImageStream(Color color1, Color color2, int width = 250, int height = 50)
        {
            var rnd = new Random();
            var bmp = new Bitmap(width, height);
            for (int y = 0; y < bmp.Height; ++y)
            {
                int num = rnd.Next(1, 20);
                for (int x = 0; x < bmp.Width; ++x)
                    bmp.SetPixel(x, y, (x % num == 0) ? color1 : color2);
            }
            var memStream = new MemoryStream();
            bmp.Save(memStream, ImageFormat.Png);
            memStream.Position = 0;
            return new StreamContent(memStream);
        }
        #endregion
    }

    public class ImageData
    {
        public string Data { get; set; }
    }
}
