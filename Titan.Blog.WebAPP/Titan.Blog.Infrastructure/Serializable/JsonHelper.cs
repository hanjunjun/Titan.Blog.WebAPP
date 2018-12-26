/************************************************************************
 * 文件名：JsonHelper
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2018/12/21 14:42:11
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Titan.Blog.Infrastructure.Serializable
{
    public class JsonHelper
    {
        /// <summary>
        /// 将Json模型转换成json字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String ModelToStr(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 将字符串转换成Json模型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T StrToModel<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将Json模型转换成byte[]数组
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static byte[] ModelToBytes(object item)
        {
            var jsonString = JsonConvert.SerializeObject(item);

            return Encoding.UTF8.GetBytes(jsonString);
        }
    }
}
