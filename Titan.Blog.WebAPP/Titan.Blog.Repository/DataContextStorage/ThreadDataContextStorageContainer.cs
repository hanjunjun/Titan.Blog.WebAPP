/************************************************************************
 * 文件名：ThreadDataContextStorageContainer
 * 文件功能描述：线程数据上下文缓存接口
 * 作    者：hjj
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using Titan.Model.DataModel;
using System.Collections;
using System.Threading;

namespace Titan.RepositoryCode.DataContextStorage
{
    public class ThreadDataContextStorageContainer : IDataContextStorageContainer
    {
        private static readonly Hashtable _libraryDataContexts = new Hashtable();

        /// <summary>
        /// 获取线程上下文
        /// </summary>
        /// <returns></returns>
        public ModelBaseContext GetDataContext()
        {
            ModelBaseContext libraryDataContext = null;

            if (_libraryDataContexts.Contains(GetThreadName()))
                libraryDataContext = (ModelBaseContext)_libraryDataContexts[GetThreadName()];

            return libraryDataContext;
        }

        /// <summary>
        /// 执行缓存
        /// </summary>
        /// <param name="libraryDataContext"></param>
        public void Store(ModelBaseContext libraryDataContext)
        {
            if (_libraryDataContexts.Contains(GetThreadName()))
                _libraryDataContexts[GetThreadName()] = libraryDataContext;
            else
                _libraryDataContexts.Add(GetThreadName(), libraryDataContext);
        }

        /// <summary>
        /// 获取当前线程名称
        /// </summary>
        /// <returns></returns>
        private static string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}