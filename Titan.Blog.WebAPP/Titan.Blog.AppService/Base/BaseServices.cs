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
        public async Task Add(T entity)
        {
            await BaseRepository.Add(entity);
        }

        public Task<List<T>> AsNoTracking()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> AsNoTracking(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> AsNoTracking(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> AsNoTracking(Expression<Func<T, bool>> where, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> AsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> AsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> AsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> AsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.AsNoTracking<A>(where,orderBy1,orderBy2, isAsc, pageIndex,pageSize);
        }

        public Task<List<T>> AsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> AsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> AsNoTracking<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> AsNoTracking<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> AsNoTracking<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> AsNoTracking<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteSql(string sql)
        {
            throw new NotImplementedException();
        }

        public Task ExecuteSql(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> Query(Expression<Func<T, bool>> where, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public async Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize)
        {
            return await BaseRepository.Query(where, orderBy1, isAsc, pageIndex, pageSize);
        }

        public Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc)
        {
            throw new NotImplementedException();
        }

        public Task<Tuple<List<T>, int>> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryAsNoTrackingById(TEntity id)
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryById(TEntity id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryBySql(string querySql)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryBySql(string querySql, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
