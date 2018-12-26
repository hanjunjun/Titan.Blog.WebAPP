/************************************************************************
 * 文件名：DataContextStorageFactory
 * 文件功能描述：数据上下文缓存工厂
 * 作    者：hjj
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using System.Web;
using Microsoft.AspNetCore.Http;
using Titan.Blog.Infrastructure.HttpExtenions;

namespace Titan.RepositoryCode.DataContextStorage
{
    public class DataContextStorageFactory
    {
        public static IDataContextStorageContainer _dataContectStorageContainer;

        /// <summary>
        /// 获取缓存上下文
        /// </summary>
        /// <returns></returns>
        public static IDataContextStorageContainer CreateStorageContainer()
        {
            if (_dataContectStorageContainer == null)
            {
                if (Blog.Infrastructure.HttpExtenions.HttpContext.Current == null)
                    _dataContectStorageContainer = new ThreadDataContextStorageContainer();
                else
                    _dataContectStorageContainer = new HttpDataContextStorageContainer();
            }

            return _dataContectStorageContainer;
        }
    }
}