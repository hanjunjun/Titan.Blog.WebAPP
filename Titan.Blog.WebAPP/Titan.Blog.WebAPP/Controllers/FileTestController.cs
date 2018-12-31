using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Titan.Blog.Infrastructure.Data;
using Titan.Blog.Infrastructure.File;
using Titan.Blog.WebAPP.Extensions;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.Controllers
{
    [CustomRoute]
    [Authorize("Permission")]
    public class FileTestController: ApiControllerBase
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        public FileTestController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        #region 文件上传下载
        /// <summary>
        /// 上传文件（单个文件）
        /// </summary>
        /// <returns></returns>
        [HttpPost("UploadFile",Name = "UploadFile")]
        public async Task<OpResult<string>> UploadFile(IFormFile file, IFormFile file1)
        {
            var date = Request;
            var files = Request.Form.Files;
            if (files.Count == 0)
                return new OpResult<string>(OpResultType.ValidError, "", $"文件未上传，请上传文件！");
            long size = files.Sum(f => f.Length);//获取文件大小
            if (size > 1024*1024*1024)
                return new OpResult<string>(OpResultType.ValidError, "", $"图片过大，图片大小为1M！");
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var nameList = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string fileExt = formFile.FileName.Substring(formFile.FileName.LastIndexOf('.'), formFile.FileName.Length - formFile.FileName.LastIndexOf('.'));//获取后缀名
                    long fileSize = formFile.Length; //获得文件大小，以字节为单位
                    var newFileName = Guid.NewGuid().ToString() + fileExt; //随机生成新的文件名
                    nameList.Add(newFileName);
                    string path = $"{webRootPath}/Files/UploadFiles";//文件夹路径
                    if (!PathHelper.IsExist(path))//查询目录是否存在
                        PathHelper.CreateFiles(path);//创建目录
                    var filePath = $"{path}/{ newFileName}";//文件路径
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return new OpResult<string>(OpResultType.Success, "", $"{DateTime.Now} {string.Join(',', nameList)}上传文件成功");
        }

        /// <summary>
        /// 上传文件（多个文件，Swagger UI暂时不支持，可以用postman测试多文件上传）
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("UploadFileList", Name = "UploadFileList")]
        public async Task<OpResult<string>> UploadFile(List<IFormFile> file)
        {
            var date = Request;
            var files = Request.Form.Files;
            if (files.Count == 0)
                return new OpResult<string>(OpResultType.ValidError, "", $"文件未上传，请上传文件！");
            long size = files.Sum(f => f.Length);//获取文件大小
            if (size > 1024 * 1024 * 1024)
                return new OpResult<string>(OpResultType.ValidError, "", $"图片过大，图片大小为1M！");
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    string fileExt = formFile.FileName.Substring(formFile.FileName.LastIndexOf('.'), formFile.FileName.Length - formFile.FileName.LastIndexOf('.'));//获取后缀名
                    long fileSize = formFile.Length; //获得文件大小，以字节为单位
                    var newFileName = Guid.NewGuid().ToString() + fileExt; //随机生成新的文件名
                    string path = $"{webRootPath}/Files/UploadFiles";//文件夹路径
                    if (!PathHelper.IsExist(path))//查询目录是否存在
                        PathHelper.CreateFiles(path);//创建目录
                    var filePath = $"{path}/{ newFileName}";//文件路径
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return new OpResult<string>(OpResultType.Success, "", $"{DateTime.Now}上传文件成功");
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("DownloadFile/{fileName}", Name = "DownloadFile")]
        public FileResult downloadRequest(string fileName)
        {
            //var addrUrl = webRootPath + "/upload/thumb.jpg";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            var addrUrl = webRootPath+ $@"\Files\UploadFiles\{fileName}";

            var stream = System.IO.File.OpenRead(addrUrl);

            string fileExt = Path.GetExtension(fileName);

            //获取文件的ContentType

            var provider = new FileExtensionContentTypeProvider();

            var memi = provider.Mappings[fileExt];

            return File(stream, memi, Path.GetFileName(addrUrl));
        }
        #endregion
    }
}
