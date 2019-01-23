/************************************************************************
 * 文件名：IRepository
 * 文件功能描述：数据操作接口
 * 作    者：Titan.Han
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/

using Titan.Blog.Model;

namespace Infrastructure.Domain
{
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId> where T : AggregateRoot
    {
        /// <summary>
        /// 保存对象
        /// </summary>
        /// <param name="entity"></param>
        void Save(T entity);
        /// <summary>
        /// 新增对象
        /// </summary>
        /// <param name="entity"></param>
        void Add(T entity);
        /// <summary>
        /// 移除对象
        /// </summary>
        /// <param name="entity"></param>
        void Remove(T entity);
    }
}