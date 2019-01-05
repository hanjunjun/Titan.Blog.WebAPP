/************************************************************************
 * 文件名：SpireDocHelper
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/4 10:08:14
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Spire.Doc;
using Spire.Doc.Documents;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.Infrastructure.File;

namespace Titan.Blog.Infrastructure.Office
{
    public class SpireDocHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public SpireDocHelper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public  OpResult<Stream> SwaggerHtmlToWord(string html,out string memi,out string fileExten)
        {
            fileExten = ".docx";
            string fileName = Guid.NewGuid().ToString() + ".docx";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string path = webRootPath + @"\Files\TempFiles\";
            var addrUrl = path + $"{fileName}";
            FileStream fileStream = null;
            var provider = new FileExtensionContentTypeProvider();
            memi = provider.Mappings[".docx"];
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                var data = System.Text.Encoding.Default.GetBytes(html);
                //byte[] data = Encoding.Default.getbyte(ByteHelpe.html); 
                var stream = ByteHelper.BytesToStream(data);
                //创建Document实例
                Document document = new Document();
                //加载HTML文档
                //document.LoadFromFile("APIDocument.html", FileFormat.Html, XHTMLValidationType.None);
                document.LoadFromStream(stream, FileFormat.Html, XHTMLValidationType.None);
                //保存为Word
                document.SaveToFile(addrUrl, FileFormat.Docx);
                document.Close();
                fileStream = System.IO.File.Open(addrUrl, FileMode.Open);
                var filedata = ByteHelper.StreamToBytes(fileStream);
                var outdata = ByteHelper.BytesToStream(filedata);
                return new OpResult<Stream>(OpResultType.Success,"转换成功！", outdata);
            }
            catch (Exception e)
            {
                return new OpResult<Stream>(OpResultType.Error,$"转换失败，{e.Message}",null);
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
