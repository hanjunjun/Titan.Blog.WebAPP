/************************************************************************
 * 文件名：RespositoryBase
 * 文件功能描述：数据处理基类
 * 作    者：hjj
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using Titan.Model.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Globalization;
using Infrastructure.Domain;
using Microsoft.EntityFrameworkCore;
using Titan.Infrastructure.UnitofWork;
using Titan.Model;

namespace Titan.RepositoryCode.Respositorys
{
    public class RespositoryBase<T, EntityKey> :
        IReadOnlyRepository<T, EntityKey>,
        IUnitOfWorkRepository where T : IAggregateRoot, new()
    {
        private IUnitOfWork _uow = new EFUnitOfWork();
        public ModelBaseContext context = DataContextFactory.GetDataContext();

        public RespositoryBase()
        {

        }

        #region 基础查询
        /// <summary>
        /// 添加对象
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            _uow.RegisterNew(entity, this);
        }

        /// <summary>
        /// 删除对象
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(T entity)
        {
            _uow.RegisterRemoved(entity, this);
        }

        /// <summary>
        /// 修改对象
        /// </summary>
        /// <param name="entity"></param>
        public void Save(T entity)
        {

            _uow.RegisterAmended(entity, this);
            // Do nothing as EF tracks changes
        }
        #endregion

        #region 扩展查询
        public IQueryable<T> GetObjectSet()
        {
            return context.Set<T>();
        }

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public T FindById(EntityKey Id)
        {
            return context.Set<T>().Find(Id);
        }

        /// <summary>
        /// 按照条件查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IList<T> GetDatas(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        /// <summary>
        /// 按照条件查询并不进行上下文缓存
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IList<T> GetDatasNoTracking(Expression<Func<T, bool>> predicate)
        {
            return new ModelBaseContext(new DbContextOptions<ModelBaseContext>()).Set<T>().AsNoTracking().Where(predicate).ToList();
        }

        /// <summary>
        /// 按条件查询，排序
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindList<S>(Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, S>> orderBy2,
            bool isAsc)
        {
            var list = context.Set<T>().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).ThenBy<T, S>(orderBy2);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, S>(orderBy2);
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1);
                }
            }
            return list;
        }

        /// <summary>
        /// 按条件查询，排序
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindList3<S>(Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, S>> orderBy2, Expression<Func<T, S>> orderBy3,
            bool isAsc)
        {
            var list = context.Set<T>().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (orderBy3 != null)
                    {
                        if (isAsc)
                            list = list.OrderBy<T, S>(orderBy1).ThenBy<T, S>(orderBy2).ThenBy<T, S>(orderBy3);
                        else
                            list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, S>(orderBy2).ThenByDescending<T, S>(orderBy3);
                    }
                    else
                    {
                        if (isAsc)
                            list = list.OrderBy<T, S>(orderBy1).ThenBy<T, S>(orderBy2);
                        else
                            list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, S>(orderBy2);
                    }
                    
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1);
                }
            }
            
            return list;
        }


        /// <summary>
        /// 按条件查询，排序(多组合排序)
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindListOrderBy<S,Y>(Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, Y>> orderBy2,
            bool isAsc)
        {
            var list = context.Set<T>().Where(where);
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).ThenBy<T, Y>(orderBy2);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, Y>(orderBy2);
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1);
                }
            }
            return list;
        }

        /// <summary>
        /// 按条件查询，排序(多组合排序)
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindListOrderBy<S, Y>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, Y>> orderBy2,
            bool isAsc)
        {
            var list = context.Set<T>().Where(where);
            rowCount = list.Count();
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).ThenBy<T, Y>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, Y>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
            }
            return list;
        }


        /// <summary>
        /// 按条件查询，分页
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where)
        {
            var list = GetObjectSet();
            if (where != null)
                list = context.Set<T>().Where(where);
            rowCount = list.Count();
            list = list.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
            return list;
        }


        /// <summary>
        /// 按条件查询，分页，排序
        /// </summary>
        /// <typeparam name="S"><peparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList<S>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, S>> orderBy2,
            bool isAsc)
        {
            var list = GetObjectSet();
            if (where != null)
                list = context.Set<T>().Where(where);
            rowCount = list.Count();
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).ThenBy<T, S>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, S>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }

            }

            return list;
        }

        public IQueryable<T> FindPagedListOrderBy<S, Y>(int pageIndex, int pageSize, out int rowCount,Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, Y>> orderBy2,
            bool isAsc)
        {
            var list = GetObjectSet();
            if (where != null)
                list = context.Set<T>().Where(where);
            rowCount = list.Count();
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).ThenBy<T, Y>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, Y>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }

            }

            return list;
        }

        /// <summary>
        /// 按条件查询，分页，排序
        /// </summary>
        /// <typeparam name="S"><peparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList2<S,Q>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, Q>> orderBy2,
            bool isAsc)
        {
            var list = GetObjectSet();
            if (where != null)
                list = context.Set<T>().Where(where);
            rowCount = list.Count();
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).ThenBy<T, Q>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, Q>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }

            }
            return list;
        }

        /// <summary>
        /// 按条件查询，分页，排序
        /// </summary>
        /// <typeparam name="S"><peparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList3<S, Q,W>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, Q>> orderBy2, Expression<Func<T, W>> orderBy3,
            bool isAsc)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("zh-cn");
            var list = GetObjectSet();
            if (where != null)
                list = context.Set<T>().Where(where);
            rowCount = list.Count();
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (orderBy3 != null)
                    {
                        if (isAsc)
                            list = list.OrderBy<T, S>(orderBy1).ThenBy<T, Q>(orderBy2).ThenBy<T, W>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                        else
                        {
                            list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, Q>(orderBy2).ThenByDescending<T, W>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                            //list.OrderByDescending(x => x.SubsidyOperat.SysCompany.CompanyName, StringComparer.Create(culture, true)).ThenByDescending(x => x.CheckData.ConserveId, StringComparer.Create(culture, true)).ThenByDescending(x => x.CheckData.ElderBase.ElderName, StringComparer.Create(culture, true));
                                //.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                        }
                            
                            
                    }
                    else
                    {
                        if (isAsc)
                            list = list.OrderBy<T, S>(orderBy1).ThenBy<T, Q>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                        else
                            list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, Q>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    }
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }

            }
            return list;
        }

        /// <summary>
        /// 按条件查询，分页，排序(私人方法，请勿修改)
        /// </summary>
        /// <typeparam name="S"><peparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="rowCount"></param>
        /// <param name="where"></param>
        /// <param name="orderBy"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> FindPagedList3_zdd<S, Q, W>(int pageIndex, int pageSize, out int rowCount, Expression<Func<T, bool>> where,
            Expression<Func<T, S>> orderBy1, Expression<Func<T, Q>> orderBy2, Expression<Func<T, W>> orderBy3,
            bool isAsc)
        {
            CultureInfo culture = CultureInfo.GetCultureInfo("zh-cn");
            var list = GetObjectSet();
            if (where != null)
                list = context.Set<T>().Where(where);
            rowCount = list.Count();
            if (orderBy1 != null)
            {
                if (orderBy2 != null)
                {
                    if (orderBy3 != null)
                    {
                        if (isAsc)
                            list = list.OrderBy<T, S>(orderBy1).ThenBy<T, Q>(orderBy2).ThenBy<T, W>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                        else
                        {
                            list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, Q>(orderBy2).ThenByDescending<T, W>(orderBy3);
                            //list.OrderByDescending(x => x.SubsidyOperat.SysCompany.CompanyName, StringComparer.Create(culture, true)).ThenByDescending(x => x.CheckData.ConserveId, StringComparer.Create(culture, true)).ThenByDescending(x => x.CheckData.ElderBase.ElderName, StringComparer.Create(culture, true));
                            //.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                        }


                    }
                    else
                    {
                        if (isAsc)
                            list = list.OrderBy<T, S>(orderBy1).ThenBy<T, Q>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                        else
                            list = list.OrderByDescending<T, S>(orderBy1).ThenByDescending<T, Q>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    }
                }
                else
                {
                    if (isAsc)
                        list = list.OrderBy<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                    else
                        list = list.OrderByDescending<T, S>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                }

            }
            return list;
        }
        /// <summary>
        /// 查询所有对象数据
        /// </summary>
        /// <returns>集合</returns>
        public IEnumerable<T> FindAll()
        {
            return GetObjectSet().ToList<T>();
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns>集合</returns>
        public IEnumerable<T> FindAll(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList<T>();
        }

        /// <summary>
        /// 带条件分页查询
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <param name="asc">是否正序</param>
        /// <param name="orderBy">排序字段</param>
        /// <param name="index"></param>
        /// <param name="count"></param>
        /// <returns>集合</returns>
        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, bool asc, Func<T, object> orderBy, int index, int count)
        {
            if (asc)
                return GetObjectSet().Where(predicate).OrderBy(orderBy).Skip(index).Take(count).ToList<T>();
            else
                return GetObjectSet().Where(predicate).OrderByDescending(orderBy).Skip(index).Take(count).ToList<T>();
        }


        ///// <summary>
        ///// SQL语句查询
        ///// </summary>
        ///// <param name="query"></param>
        ///// <returns>集合</returns>
        //public IEnumerable<T> FindBy(string query)
        //{
        //    return context.Database.SqlQuery<T>(query).ToList();
        //}

        //public IEnumerable<T> FindBy(string query, int index, int count)
        //{
        //    return context.Database.SqlQuery<T>(query).Skip(index).Take(count).ToList<T>();
        //}

        public Type GetEntityType()
        {
            return typeof(T);
        }
        #endregion

        #region 工作单元
        public void PersistCreationOf(IAggregateRoot entity)
        {
            context.Set<IAggregateRoot>().Add(entity);
            _uow.Commit();
        }

        public void PersistUpdateOf(IAggregateRoot entity)
        {
            context.Set<IAggregateRoot>().Update(entity);
            //context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _uow.Commit();
            // Do nothing as EF tracks changes
        }

        public void PersistDeletionOf(IAggregateRoot entity)
        {
            context.Set<IAggregateRoot>().Remove(entity);
            _uow.Commit();
        }

        #endregion
    }
}