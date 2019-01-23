/************************************************************************
 * 文件名：IReadOnlyRepository
 * 文件功能描述：数据查询接口
 * 作    者：Titan.Han
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Titan.Blog.Model;

namespace Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : AggregateRoot
    {
        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>集合</returns>
        T FindById(TId id);

        /// <summary>
        /// 查询<see cref="T"/>的所有数据
        /// </summary>
        /// <returns>集合</returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// 分页查询<see cref="T"/>>的所有数据
        /// </summary>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns>集合</returns>
        IEnumerable<T> FindAll(int pageIndex, int pageSize);

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="predicate">lambda条件</param>
        /// <returns>集合</returns>
        IList<T> GetDataByValue(Expression<Func<T, bool>> predicate);

    }
}