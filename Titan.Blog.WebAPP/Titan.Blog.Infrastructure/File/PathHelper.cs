using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Titan.Blog.Infrastructure.File
{
    public static class PathHelper
    {
        /// <summary>
        /// 是否是绝对路径
        /// windows下判断 路径是否包含 ":"
        /// Mac OS、Linux下判断 路径是否包含 "\"
        /// </summary>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static bool IsAbsolute(string path)
        {
            return Path.VolumeSeparatorChar == ':' ? path.IndexOf(Path.VolumeSeparatorChar) > 0 : path.IndexOf('\\') > 0;
        }
        /// <summary>
        /// 路径是否存在
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsExist(string path)
        {
            return Directory.Exists(path);
        }
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path"></param>
        public static void CreateFiles(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        /// <summary>
        /// 备份文件
        /// </summary>
        /// <param name="sourcefile">文件路径</param>
        /// <param name="targetfile">备份文件路径</param>
        /// <param name="filename">文件名</param>
        public static void Backup(string sourcefile, string targetfile, string filename)
        {
            if (!Directory.Exists(targetfile))
            {
                Directory.CreateDirectory(targetfile);
            }
            System.IO.File.Copy(sourcefile, $"{targetfile}/{filename}", true);
        }
    }

}
