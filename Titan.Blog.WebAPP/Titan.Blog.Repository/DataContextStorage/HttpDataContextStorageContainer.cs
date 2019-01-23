/************************************************************************
 * 文件名：HttpDataContextStorageContainer
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
using Titan.Blog.Model.DataModel;
using ModelBaseContext = Titan.Blog.Repository.EFCore.ModelBaseContext;


namespace Titan.RepositoryCode.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private string _dataContextKey = "DataContext";
         
        /// <summary>
        /// 获取上下文
        /// </summary>
        /// <returns></returns>
        public ModelBaseContext GetDataContext()
        {
            ModelBaseContext objectContext = null;
            if (Blog.Infrastructure.HttpExtenions.HttpContext.Current.Items.ContainsKey(_dataContextKey))
                objectContext = (ModelBaseContext)Blog.Infrastructure.HttpExtenions.HttpContext.Current.Items[_dataContextKey];

            return objectContext;
        }

        /// <summary>
        /// 获取缓存上下文
        /// </summary>
        /// <param name="libraryDataContext"></param>
        public void Store(ModelBaseContext libraryDataContext)
        {
            if (Blog.Infrastructure.HttpExtenions.HttpContext.Current.Items.ContainsKey(_dataContextKey))
                Blog.Infrastructure.HttpExtenions.HttpContext.Current.Items[_dataContextKey] = libraryDataContext;
            else
                Blog.Infrastructure.HttpExtenions.HttpContext.Current.Items.Add(_dataContextKey, libraryDataContext);
        }
    }
}