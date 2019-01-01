/************************************************************************
 * 文件名：AutoMapperHelper
 * 文件功能描述：AutoMapper扩展帮助类
 * 作    者：hjj
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using AutoMapper;
using System.Collections.Generic;
using System.Data;

namespace Titan.Infrastructure.Domain
{
    /// <summary>
    /// AutoMapper扩展帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this List<TSource> source)
        {
            //foreach (TSource first in source)
            //{
            //    //var type = first.GetType();
            //    Mapper.CreateMap(typeof(TSource), typeof(TDestination));
            //    break;
            //}
            return Mapper.Map<List<TSource>, List<TDestination>>(source);
        }

        /// <summary>
        /// 类型映射
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
            where TSource : class
            where TDestination : class
        {
            if (source == null) return destination;
            //var map = Mapper.CreateMap<TSource, TDestination>();
            //  map.ForMember(d => d, opt => opt.MapFrom(x => x.TB_DEPARTMENT.NAME));

            return Mapper.Map(source, destination);
        }
        /// <summary>
        /// DataReader映射
        /// </summary>
        public static IEnumerable<T> DataReaderMapTo<T>(this IDataReader reader)
        {
            Mapper.Reset();
            //Mapper.CreateMap<IDataReader, IEnumerable<T>>();
            return Mapper.Map<IDataReader, IEnumerable<T>>(reader);
        }

        /// <summary>
        /// 进行指向链接
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        //public static IMappingExpression<TSource, TDestination> ToMapp<TSource, TDestination>(this TSource source, TDestination destination)
        //     where TSource : class
        //    where TDestination : class
        //{
        //    return CreateMap<TSource, TDestination>();
        //}
    }
}