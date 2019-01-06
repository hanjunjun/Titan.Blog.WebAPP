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
    /// <summary>
    /// Swagger 自定义功能
    /// </summary>
    [CustomRoute]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SwaggerController: ApiControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly SpireDocHelper _spireDocHelper;
        private readonly SwaggerGenerator _swaggerGenerator;//
        public SwaggerController(IHostingEnvironment hostingEnvironment, SpireDocHelper spireDocHelper, SwaggerGenerator swaggerGenerator)
        {
            _hostingEnvironment = hostingEnvironment;
            _spireDocHelper = spireDocHelper;
            _swaggerGenerator = swaggerGenerator;//从ioc容器中获取swagger生成文档的对象
        }

        /// <summary>
        /// Swagger 文档导出
        /// </summary>
        /// <param name="type"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpGet("ExportApiWord", Name = "ExportApiWord")]
        public FileResult ExportApiWord(string type,string version)
        {
            string memi=string.Empty;
            string fileExten = string.Empty;
            Stream outdata=null;
            //获取swagger json 之前通过swagger的接口获取，废弃了。原因：他返回的数据看着像json数据，实则不是，不能用newtonsoft反序列化成对象。
            //var url = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/swagger/v2/swagger.json";
            //var data = RestSharpHelper.HttpGet(url);
            //var model = JsonHelper.StrToModel<OpenApiDocument>(data);

            //1.获取api文档json，version是版本，根据指定版本获取指定版本的json对象。
            var model = _swaggerGenerator.GetSwagger(version);
            if (model == null)
            {
                throw new Exception("Swagger Json cannot be equal to null！");
            }
            //2.这里使用了微软的mvc模板引擎技术来生成html，做过mvc项目的同学应该都知道是啥东西，这里不细说了。自己看代码吧，用起来很方便。
            var html = T4Helper.GeneritorSwaggerHtml($"{_hostingEnvironment.WebRootPath}\\SwaggerDoc.cshtml",model);
            //3.将html转换成需要导出的文件类型。
            var op = _spireDocHelper.SwaggerHtmlConvers(html, type, out memi);
            if (!op.Successed)
            {
                throw new Exception(op.Message);
            }
            outdata = op.Data;
            return File(outdata, memi, $"Titan.Blog.WebAPP API文档 {version}{type}");//返回文件流，type是文件格式
        }
    }
}
