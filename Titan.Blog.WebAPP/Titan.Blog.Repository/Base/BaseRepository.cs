/************************************************************************
 * 文件名：BaseRepository
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/22 11:30:50
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Titan.Blog.IRepository.Base;
using Titan.Blog.Model;
using Titan.Blog.Model.DataModel;
using Titan.Blog.Repository.EFCore;
using Titan.RepositoryCode;

namespace Titan.Blog.Repository.Base
{
    public class BaseRepository<T, TEntityKey> : IBaseRepository<T, TEntityKey> where T : AggregateRoot, new()
    {
        #region 成员及构造

        private ModelBaseContext _context;// = DataContextFactory.GetDataContext();//从httpcontext中获取ef上下文

        public BaseRepository(ModelBaseContext contex)
        {
            _context = contex;
        }
        #endregion

        #region 增删改操作
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Add(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            });
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Delete(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            });
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Update(entity);
                _context.SaveChanges();
            });
        }
        #endregion

        #region  SQL CURD操作
        /// <summary>
        /// SQL语句查询
        /// </summary>
        /// <param name="querySql">SQL语句</param>
        /// <returns></returns>
        public async Task<List<T>> QueryBySql(string querySql)
        {
            return await Task.Run(() => _context.Set<T>().FromSql(querySql).ToList());
        }

        /// <summary>
        /// SQL语句分页查询
        /// </summary>
        /// <param name="querySql">SQL语句</param>
        /// <param name="pageIndex">页面索引</param>
        /// <param name="pageSize">页面大小</param>
        /// <returns></returns>
        public async Task<List<T>> QueryBySql(string querySql, int pageIndex, int pageSize)
        {
            return await Task.Run(() => _context.Set<T>().FromSql(querySql).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList());
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task ExecuteSql(string sql)
        {
            await Task.Run(() => _context.Database.ExecuteSqlCommand(sql));
        }

        /// <summary>
        /// 执行SQL带参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task ExecuteSql(string sql, params object[] parameters)
        {
            await Task.Run(() => _context.Database.ExecuteSqlCommand(sql, parameters));
        }
        #endregion

        #region 跟踪查询
        /// <summary>
        /// 根据主键Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> QueryById(TEntityKey id)
        {
            return await Task.Run(() => _context.Set<T>().Find(id));
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> Query()
        {
            return await Task.Run(() => _context.Set<T>().ToList());
        }

        /// <summary>
        /// 分页查询<see cref="T"/>所有数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<T>> Query(int pageIndex, int pageSize)
        {
            return await Task.Run(() => _context.Set<T>().Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList());
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<List<T>> Query(Expression<Func<T, bool>> where)
        {
            return await Task.Run(() => _context.Set<T>().Where(where).ToList());
        }

        public async Task<Tuple<List<T>, int>> Query(Expression<Func<T, bool>> where, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet();
                if (where != null)
                    list = _context.Set<T>().Where(where);
                list = list.Skip(pageSize * (pageIndex - 1)).Take(pageSize);
                return new Tuple<List<T>, int>(list.ToList(), list.Count());
            });
        }

        public async Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, bool isAsc)
        {
            return await Task.Run(() =>
            {
                if (isAsc)
                {
                    return GetObjectSet().Where(where).OrderBy(orderBy1).ToList();
                }
                else
                {
                    return GetObjectSet().Where(where).OrderByDescending(orderBy1).ToList();
                }
            });
        }

        public async Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                if (isAsc)
                {
                    return new Tuple<List<T>, int>(GetObjectSet().Where(where).OrderBy(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), GetObjectSet().Where(where).Count());
                }
                else
                {
                    return new Tuple<List<T>, int>(GetObjectSet().Where(where).OrderByDescending(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), GetObjectSet().Where(where).Count());
                }
            });
        }

        public async Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, A> orderBy2, bool isAsc)
        {
            return await Task.Run(() =>
            {
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return _context.Set<T>().Where(where).OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).ToList();
                        else
                            return _context.Set<T>().Where(where).OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).ToList();
                    }
                    else
                    {
                        if (isAsc)
                            return _context.Set<T>().Where(where).OrderBy<T, A>(orderBy1).ToList();
                        else
                            return _context.Set<T>().Where(where).OrderByDescending<T, A>(orderBy1).ToList();
                    }
                }
                else
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return _context.Set<T>().Where(where).OrderBy<T, A>(orderBy2).ToList();
                        else
                            return _context.Set<T>().Where(where).OrderByDescending<T, A>(orderBy2).ToList();
                    }
                    else
                    {
                        return _context.Set<T>().Where(where).ToList();//排序都为null
                    }
                }
            });
        }

        public async Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, A> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = GetObjectSet();
                if (where != null)
                    list = _context.Set<T>().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
                else
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                    else
                    {
                        return new Tuple<List<T>, int>(list.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
            });
        }

        public async Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, A> orderBy2, Func<T, A> orderBy3, bool isAsc)
        {
            return await Task.Run(() =>
            {
                var list = _context.Set<T>().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (orderBy3 != null)
                        {
                            if (isAsc)
                                return list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).ThenBy<T, A>(orderBy3)
                                    .ToList();
                            else
                                return list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2)
                                    .ThenByDescending<T, A>(orderBy3).ToList();
                        }
                        else
                        {
                            if (isAsc)
                                return list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).ToList();
                            else
                                return list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).ToList();
                        }

                    }
                    else
                    {
                        if (isAsc)
                            return list.OrderBy<T, A>(orderBy1).ToList();
                        else
                            return list.OrderByDescending<T, A>(orderBy1).ToList();
                    }
                }

                return list.ToList();
            });
        }

        public async Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, A> orderBy2, Func<T, A> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = _context.Set<T>().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (orderBy3 != null)
                        {
                            if (isAsc)
                                return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).ThenBy<T, A>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                            else
                                return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2)
                                    .ThenByDescending<T, A>(orderBy3).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        }
                        else
                        {
                            if (isAsc)
                                return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                            else
                                return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, A>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        }

                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
                return new Tuple<List<T>, int>(list.Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
            });
        }

        public async Task<List<T>> Query<A, B>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, B> orderBy2, bool isAsc)
        {
            return await Task.Run(() =>
            {
                var list = _context.Set<T>().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return _context.Set<T>().Where(where).OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).ToList();
                        else
                            return _context.Set<T>().Where(where).OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).ToList();
                    }
                    else
                    {
                        if (isAsc)
                            return list.OrderBy<T, A>(orderBy1).ToList();
                        else
                            return list.OrderByDescending<T, A>(orderBy1).ToList();
                    }
                }
                else
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return _context.Set<T>().Where(where).OrderBy<T, B>(orderBy2).ToList();
                        else
                            return _context.Set<T>().Where(where).OrderByDescending<T, B>(orderBy2).ToList();
                    }
                    else
                    {
                        return _context.Set<T>().Where(where).ToList();
                    }
                }
            });
        }

        public async Task<Tuple<List<T>, int>> Query<A, B>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, B> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await Task.Run(() =>
            {
                var list = _context.Set<T>().Where(where);
                if (orderBy1 != null)
                {
                    if (orderBy2 != null)
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).ThenBy<T, B>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).ThenByDescending<T, B>(orderBy2).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                    else
                    {
                        if (isAsc)
                            return new Tuple<List<T>, int>(list.OrderBy<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                        else
                            return new Tuple<List<T>, int>(list.OrderByDescending<T, A>(orderBy1).Skip(pageSize * (pageIndex - 1)).Take(pageSize).ToList(), list.Count());
                    }
                }
                return new Tuple<List<T>, int>(list.ToList(), list.Count());
            });
        }

        public async Task<List<T>> Query<A, B, C>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, B> orderBy2, Func<T, C> orderBy3, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> Query<A, B, C>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, B> orderBy2, Func<T, C> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region AsNoTracking非跟踪查询
        public async Task<T> QueryAsNoTrackingById(TEntityKey id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<T>> AsNoTracking()
        {
            return await Task.Run(() => _context.Set<T>().AsNoTracking().ToList());
        }

        public async Task<List<T>> AsNoTracking(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> AsNoTracking(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> AsNoTracking(Expression<Func<T, bool>> where, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> AsNoTracking<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> AsNoTracking<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> AsNoTracking<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, A> orderBy2, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> AsNoTracking<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, A> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> AsNoTracking<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, A> orderBy2, Func<T, A> orderBy3, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> AsNoTracking<A>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, A> orderBy2, Func<T, A> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> AsNoTracking<A, B>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, B> orderBy2, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> AsNoTracking<A, B>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, B> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> AsNoTracking<A, B, C>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, B> orderBy2, Func<T, C> orderBy3, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> AsNoTracking<A, B, C>(Expression<Func<T, bool>> where, Func<T, A> orderBy1, Func<T, B> orderBy2, Func<T, C> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 公共
        public IQueryable<T> GetObjectSet()
        {
            return _context.Set<T>();
        }
        #endregion
    }
}
