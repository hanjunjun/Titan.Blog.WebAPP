/************************************************************************
 * 文件名：IDataContextStorageContainer
 * 文件功能描述：数据上下文缓存接口
 * 作    者：hjj
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using Titan.Model.DataModel;

namespace Titan.RepositoryCode.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        /// <summary>
        /// 上下文
        /// </summary>
        /// <returns></returns>
        ModelBaseContext GetDataContext();
        /// <summary>
        /// 执行缓存
        /// </summary>
        /// <param name="libraryDataContext"></param>
        void Store(ModelBaseContext libraryDataContext);
    }
}