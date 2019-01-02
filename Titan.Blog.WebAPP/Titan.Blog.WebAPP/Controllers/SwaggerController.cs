using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Spire.Doc;
using Spire.Doc.Documents;
using Titan.Blog.Infrastructure.File;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers
{
    [CustomRoute]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class SwaggerController: ApiControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public SwaggerController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpGet("ExportApiWord", Name = "ExportApiWord")]
        public FileResult ExportApiWord()
        {
            string fileName = Guid.NewGuid().ToString() + ".docx";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string path = webRootPath + @"\Files\TempFiles\";
            var addrUrl = path + $"{fileName}";
            FileStream fileStream = null;
            try
            {

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //System.Text.UnicodeEncoding converter = new System.Text.UnicodeEncoding();

                var data = System.Text.Encoding.Default.GetBytes(SwaggerExtensions.HTML);
                //byte[] data = Encoding.Default.getbyte(ByteHelpe.html); 
                var stream = ByteHelper.BytesToStream(data);
                //创建Document实例
                Document document = new Document();

                //加载HTML文档
                //document.LoadFromFile("APIDocument.html", FileFormat.Html, XHTMLValidationType.None);
                document.LoadFromStream(stream, FileFormat.Html, XHTMLValidationType.None);
                //保存为Word
                document.SaveToFile(addrUrl, FileFormat.Docx);
                //document.Close();
                fileStream = System.IO.File.Open(addrUrl, FileMode.Open);
                var filedata = ByteHelper.StreamToBytes(fileStream);
                var outdata = ByteHelper.BytesToStream(filedata);
                //获取文件的ContentType


                //TestDBContext te = new TestDBContext(new DbContextOptions<TestDBContext>());
                //var test= te.Author.ToList();
                //return new string[] { "value1", "value2" };
                var provider = new FileExtensionContentTypeProvider();
                var memi = provider.Mappings[".docx"];
                return File(outdata, memi, "Titan.Blog.WebAPP API文档.docx");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
                if (System.IO.File.Exists(addrUrl))
                    System.IO.File.Delete(addrUrl);//删掉文件
            }
        }
    }
}
