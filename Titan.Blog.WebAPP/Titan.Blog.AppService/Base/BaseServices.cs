/************************************************************************
 * 文件名：BaseServices
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/22 17:15:22
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Titan.Blog.IAppService.Base;
using Titan.Blog.IRepository.Base;
using Titan.Blog.Model;

namespace Titan.Blog.AppService.Base
{
    public class BaseServices<T, TEntity> : IBaseServices<T, TEntity> where T : AggregateRoot, new()
    {
        public IBaseRepository<T, TEntity> BaseRepository;
        #region 增删改操作
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Add(T entity)
        {
            await BaseRepository.Add(entity);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Delete(T entity)
        {
            await BaseRepository.Delete(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Update(T entity)
        {
            await BaseRepository.Update(entity);
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
            return await BaseRepository.QueryBySql(querySql);
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
            return await BaseRepository.QueryBySql(querySql, pageIndex, pageSize);
        }

        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public async Task ExecuteSql(string sql)
        {
            await ExecuteSql(sql);
        }

        /// <summary>
        /// 执行SQL带参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public async Task ExecuteSql(string sql, params object[] parameters)
        {
            await ExecuteSql(sql, parameters);
        }
        #endregion

        #region 跟踪查询
        /// <summary>
        /// 根据主键Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> QueryById(TEntity id)
        {
            return await BaseRepository.QueryById(id);
        }

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> Query()
        {
            return await BaseRepository.Query();
        }

        /// <summary>
        /// 分页查询<see cref="T"/>所有数据
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<List<T>> Query(int pageIndex, int pageSize)
        {
            return await BaseRepository.Query(pageIndex, pageSize);
        }

        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<List<T>> Query(Expression<Func<T, bool>> where)
        {
            return await BaseRepository.Query(where);
        }

        public async Task<Tuple<List<T>, int>> Query(Expression<Func<T, bool>> where, int pageIndex, int pageSize)
        {
            return await BaseRepository.Query(where, pageIndex, pageSize);
        }

        public async Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc)
        {
            return await BaseRepository.Query(where, orderBy1, isAsc);
        }

        public async Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.Query(where, orderBy1, isAsc, pageIndex, pageSize);
        }

        public async Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc)
        {
            return await BaseRepository.Query<A>(where, orderBy1, orderBy2, isAsc);
        }

        public async Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.Query<A>(where, orderBy1, orderBy2, isAsc, pageIndex, pageSize);
        }

        public async Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc)
        {
            return await BaseRepository.Query<A>(where, orderBy1, orderBy2, orderBy3, isAsc);
        }

        public async Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.Query<A>(where, orderBy1, orderBy2, orderBy3, isAsc, pageIndex, pageSize);
        }

        public async Task<List<T>> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc)
        {
            return await BaseRepository.Query<A, B>(where, orderBy1, orderBy2, isAsc);
        }

        public async Task<Tuple<List<T>, int>> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.Query<A, B>(where, orderBy1, orderBy2, isAsc, pageIndex, pageSize);
        }

        public async Task<List<T>> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc)
        {
            return await BaseRepository.Query<A, B, C>(where, orderBy1, orderBy2, orderBy3, isAsc);
        }

        public async Task<Tuple<List<T>, int>> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.Query<A, B, C>(where, orderBy1, orderBy2, orderBy3, isAsc, pageIndex, pageSize);
        }
        #endregion

        #region AsNoTracking非跟踪查询
        public async Task<T> QueryAsNoTrackingById(TEntity id)
        {
            return await BaseRepository.QueryAsNoTrackingById(id);
        }
        public async Task<List<T>> QueryAsNoTracking()
        {
            return await BaseRepository.QueryAsNoTracking();
        }

        public async Task<List<T>> QueryAsNoTracking(int pageIndex, int pageSize)
        {
            return await BaseRepository.QueryAsNoTracking();
        }

        public async Task<List<T>> QueryAsNoTracking(Expression<Func<T, bool>> where)
        {
            return await BaseRepository.QueryAsNoTracking(where);
        }

        public async Task<Tuple<List<T>, int>> QueryAsNoTracking(Expression<Func<T, bool>> where, int pageIndex, int pageSize)
        {
            return await BaseRepository.QueryAsNoTracking(where, pageIndex, pageSize);
        }

        public async Task<List<T>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc)
        {
            return await BaseRepository.QueryAsNoTracking(where, orderBy1, isAsc);
        }

        public async Task<Tuple<List<T>, int>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.QueryAsNoTracking(where, orderBy1, isAsc, pageIndex, pageSize);
        }

        public async Task<List<T>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc)
        {
            return await BaseRepository.QueryAsNoTracking<A>(where, orderBy1, orderBy2, isAsc);
        }

        public async Task<Tuple<List<T>, int>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.QueryAsNoTracking<A>(where, orderBy1, orderBy2, isAsc, pageIndex, pageSize);
        }

        public async Task<List<T>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc)
        {
            return await BaseRepository.QueryAsNoTracking<A>(where, orderBy1, orderBy2, orderBy3, isAsc);
        }

        public async Task<Tuple<List<T>, int>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.QueryAsNoTracking<A>(where, orderBy1, orderBy2, orderBy3, isAsc, pageIndex, pageSize);
        }

        public async Task<List<T>> QueryAsNoTracking<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc)
        {
            return await BaseRepository.QueryAsNoTracking<A, B>(where, orderBy1, orderBy2, isAsc);
        }

        public async Task<Tuple<List<T>, int>> QueryAsNoTracking<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.QueryAsNoTracking<A, B>(where, orderBy1, orderBy2, isAsc, pageIndex, pageSize);
        }

        public async Task<List<T>> QueryAsNoTracking<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc)
        {
            return await BaseRepository.QueryAsNoTracking<A, B, C>(where, orderBy1, orderBy2, orderBy3, isAsc);
        }

        public async Task<Tuple<List<T>, int>> QueryAsNoTracking<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.QueryAsNoTracking<A, B, C>(where, orderBy1, orderBy2, orderBy3, isAsc, pageIndex, pageSize);
        }
        #endregion
    }
}
