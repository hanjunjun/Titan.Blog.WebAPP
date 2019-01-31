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
using Titan.Blog.Infrastructure.File;
using Titan.Blog.Model.CommonModel.ResultModel;

namespace Titan.Blog.Infrastructure.Office
{
    public class SpireDocHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public SpireDocHelper(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public  OpResult<Stream> SwaggerHtmlConvers(string html,string type,out string memi)
        {
            string fileName = Guid.NewGuid().ToString() + type;
            string webRootPath = _hostingEnvironment.WebRootPath;
            string path = webRootPath + @"\Files\TempFiles\";
            var addrUrl = path + $"{fileName}";
            FileStream fileStream = null;
            var provider = new FileExtensionContentTypeProvider();
            memi = provider.Mappings[type];
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
                //document.LoadText(stream, Encoding.Default);
                //保存为Word
                switch (type)
                {
                    case ".docx":
                        //Word
                        document.SaveToFile(addrUrl, FileFormat.Docx);
                        break;
                    case ".pdf":
                        //PDF
                        document.SaveToFile(addrUrl, FileFormat.PDF);
                        break;
                    case ".html":
                        //Html
                        FileStream fs = new FileStream(addrUrl, FileMode.Append, FileAccess.Write, FileShare.None);//html直接写入不用spire.doc
                        StreamWriter sw = new StreamWriter(fs); // 创建写入流
                        sw.WriteLine(html); // 写入Hello World
                        sw.Close(); //关闭文件
                        fs.Close();
                        break;
                    case ".xml":
                        //PDF
                        document.SaveToFile(addrUrl, FileFormat.WordXml);
                        break;
                    case ".svg":
                        //PDF
                        document.SaveToFile(addrUrl, FileFormat.SVG);
                        break;
                }
                
                document.Close();
                fileStream = System.IO.File.Open(addrUrl, FileMode.OpenOrCreate);
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
