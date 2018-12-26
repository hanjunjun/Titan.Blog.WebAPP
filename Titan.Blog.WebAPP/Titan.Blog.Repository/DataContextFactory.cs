/************************************************************************
 * 文件名：DataContextFactory
 * 文件功能描述：上下文工厂
 * 作    者：hjj
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/

using Microsoft.EntityFrameworkCore;
using Titan.Model.DataModel;
using Titan.RepositoryCode.DataContextStorage;

namespace Titan.RepositoryCode
{
    public class DataContextFactory
    {
        /// <summary>
        /// 获取上下文
        /// </summary>
        /// <returns></returns>
        public static ModelBaseContext GetDataContext()
        {
            IDataContextStorageContainer _dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();

            ModelBaseContext libraryDataContext = _dataContextStorageContainer.GetDataContext();
            if (libraryDataContext == null)
            {
                libraryDataContext = new ModelBaseContext(new DbContextOptions<ModelBaseContext>());
                _dataContextStorageContainer.Store(libraryDataContext);
            }

            return libraryDataContext;
        }
    }
}