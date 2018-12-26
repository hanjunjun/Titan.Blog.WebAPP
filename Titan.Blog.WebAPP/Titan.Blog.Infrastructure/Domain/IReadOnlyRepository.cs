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
using Titan.Model;

namespace Infrastructure.Domain
{
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T FindById(TId id);
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> FindAll();
        /// <summary>
        /// 参数查询
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        IEnumerable<T> FindAll(int index, int count);
        /// <summary>
        /// 参数查询
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        //IEnumerable<T> FindBy(string query);
        ///// <summary>
        ///// 参数查询
        ///// </summary>
        ///// <param name="query"></param>
        ///// <param name="index"></param>
        ///// <param name="count"></param>
        ///// <returns></returns>
        //IEnumerable<T> FindBy(string query, int index, int count);
        /// <summary>
        /// 获取对象集合
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IList<T> GetDatas(Expression<Func<T, bool>> predicate);

    }
}