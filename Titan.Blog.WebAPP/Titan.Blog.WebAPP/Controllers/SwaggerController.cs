using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.OpenApi.Models;
using Spire.Doc;
using Spire.Doc.Documents;
using Swashbuckle.AspNetCore.SwaggerGen;
using Titan.Blog.Infrastructure.File;
using Titan.Blog.Infrastructure.Http;
using Titan.Blog.Infrastructure.Office;
using Titan.Blog.Infrastructure.Serializable;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers
{
    [CustomRoute]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SwaggerController: ApiControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly SpireDocHelper _spireDocHelper;
        private readonly SwaggerGenerator _swaggerGenerator;
        public SwaggerController(IHostingEnvironment hostingEnvironment, SpireDocHelper spireDocHelper, SwaggerGenerator swaggerGenerator)
        {
            _hostingEnvironment = hostingEnvironment;
            _spireDocHelper = spireDocHelper;
            _swaggerGenerator = swaggerGenerator;
        }

        [HttpGet("ExportApiWord", Name = "ExportApiWord")]
        public FileResult ExportApiWord(int type,string version)
        {
            string memi=string.Empty;
            string fileExten = string.Empty;
            Stream outdata=null;
            //获取swagger json
            //var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/swagger/v2/swagger.json";
            //var data = RestSharpHelper.HttpGet(url);
            //var model = JsonHelper.StrToModel<OpenApiDocument>(data);
            var model= _swaggerGenerator.GetSwagger(version);
            switch (type)
            {
                case 1:
                    //Word
                    var op = _spireDocHelper.SwaggerHtmlToWord(SwaggerExtensions.HTML, out memi,out fileExten);
                    if (!op.Successed)
                    {
                        throw new Exception(op.Message);
                    }
                    outdata = op.Data;
                    break;
                case 2:
                    //PDF
                    break;
                case 3:
                    //Html
                    break;
                case 4:
                    //Gif
                    break;
            }
            return File(outdata, memi, $"Titan.Blog.WebAPP API文档{fileExten}");
        }
    }
}
