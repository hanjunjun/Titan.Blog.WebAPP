using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Titan.Blog.Model;

namespace Titan.Blog.IRepository.Base
{
    public interface IBaseRepository<T, TEntityKey> where T: AggregateRoot,new()
    {
        #region 增删改操作
        Task Add(T entity);
        Task Delete(T entity);
        Task Update(T entity);
        #endregion

        #region SQL CURD操作
        Task<List<T>> QueryBySql(string querySql);
        Task<List<T>> QueryBySql(string querySql, int pageIndex, int pageSize);
        Task ExecuteSql(string sql);
        Task ExecuteSql(string sql, params object[] parameters);
        #endregion

        #region 跟踪查询
        Task<T> QueryById(TEntityKey id);
        Task<List<T>> Query();
        Task<List<T>> Query(int pageIndex, int pageSize);
        Task<List<T>> Query(Expression<Func<T, bool>> where);
        Task<Tuple<List<T>, int>> Query(Expression<Func<T, bool>> where, int pageIndex, int pageSize);
        Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc);
        Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize);
        Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc);
        Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize);
        Task<List<T>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc);
        Task<Tuple<List<T>, int>> Query<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize);
        Task<List<T>> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc);
        Task<Tuple<List<T>, int>> Query<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize);
        Task<List<T>> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc);
        Task<Tuple<List<T>, int>> Query<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize);
        #endregion

        #region AsNoTracking非跟踪查询
        Task<T> QueryAsNoTrackingById(TEntityKey id);
        Task<List<T>> QueryAsNoTracking();
        Task<List<T>> QueryAsNoTracking(int pageIndex, int pageSize);
        Task<List<T>> QueryAsNoTracking(Expression<Func<T, bool>> where);
        Task<Tuple<List<T>, int>> QueryAsNoTracking(Expression<Func<T, bool>> where, int pageIndex, int pageSize);
        Task<List<T>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc);
        Task<Tuple<List<T>, int>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, bool isAsc, int pageIndex, int pageSize);
        Task<List<T>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc);
        Task<Tuple<List<T>, int>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, bool isAsc, int pageIndex, int pageSize);
        Task<List<T>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc);
        Task<Tuple<List<T>, int>> QueryAsNoTracking<A>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, A>> orderBy2, Expression<Func<T, A>> orderBy3, bool isAsc, int pageIndex, int pageSize);
        Task<List<T>> QueryAsNoTracking<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc);
        Task<Tuple<List<T>, int>> QueryAsNoTracking<A, B>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, bool isAsc, int pageIndex, int pageSize);
        Task<List<T>> QueryAsNoTracking<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc);
        Task<Tuple<List<T>, int>> QueryAsNoTracking<A, B, C>(Expression<Func<T, bool>> where, Expression<Func<T, A>> orderBy1, Expression<Func<T, B>> orderBy2, Expression<Func<T, C>> orderBy3, bool isAsc, int pageIndex, int pageSize);
        #endregion
    }
}
