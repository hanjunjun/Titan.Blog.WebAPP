/************************************************************************
 * 文件名：EFUnitOfWork
 * 文件功能描述：EntityF工作单元
 * 作    者：hjj
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using Titan.Infrastructure.UnitofWork;
using Titan.Model;

namespace Titan.RepositoryCode
{
    public class EFUnitOfWork : Infrastructure.UnitofWork.IUnitOfWork
    {
        /// <summary>
        /// 执行数据处理
        /// </summary>
        public void Commit()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }

        /// <summary>
        /// 修改对象
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        public void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistUpdateOf(entity);
        }

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        public void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistCreationOf(entity);
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="unitofWorkRepository"></param>
        public void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository)
        {
            unitofWorkRepository.PersistDeletionOf(entity);
        }
    }
}