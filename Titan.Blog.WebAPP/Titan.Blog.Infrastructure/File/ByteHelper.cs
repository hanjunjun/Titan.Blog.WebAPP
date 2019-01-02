/************************************************************************
 * 文件名：ByteHelper
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/2 16:54:39
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Titan.Blog.Infrastructure.File
{
    public class ByteHelper
    {
        public static byte[] StreamToBytes(Stream stream)

        {

            byte[] bytes = new byte[stream.Length];

            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始 

            stream.Seek(0, SeekOrigin.Begin);

            return bytes;

        }

        /// 将 byte[] 转成 Stream

        public static Stream BytesToStream(byte[] bytes)

        {

            Stream stream = new MemoryStream(bytes);

            return stream;

        }
    }
}
