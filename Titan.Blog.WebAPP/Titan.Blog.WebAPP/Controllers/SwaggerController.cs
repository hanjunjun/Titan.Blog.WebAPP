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
using Titan.Blog.Infrastructure.T4;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;
using Titan.Infrastructure.Domain;

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
        public FileResult ExportApiWord(string type,string version)
        {
            string memi=string.Empty;
            string fileExten = string.Empty;
            Stream outdata=null;
            //获取swagger json
            //var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/swagger/v2/swagger.json";
            //var data = RestSharpHelper.HttpGet(url);
            //var model = JsonHelper.StrToModel<OpenApiDocument>(data);
            var model = _swaggerGenerator.GetSwagger(version);
            if (model == null)
            {
                throw new Exception("Swagger Json cannot be equal to null！");
            }
            var html = T4Helper.GeneritorSwaggerHtml($"{_hostingEnvironment.WebRootPath}\\SwaggerDoc.cshtml",model);
            var op = _spireDocHelper.SwaggerHtmlConvers(html, type, out memi);
            if (!op.Successed)
            {
                throw new Exception(op.Message);
            }
            outdata = op.Data;
            return File(outdata, memi, $"Titan.Blog.WebAPP API文档 {version}{type}");
        }
    }
}
