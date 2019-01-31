using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Blog.Infrastructure.Cache
{
    public interface ICache
    {
        /// <summary>
        /// 根据key获取缓存实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T Get<T>(string key);

        /// <summary>
        /// 根据key获取缓存字符串数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        string Get(string key);

        /// <summary>
        /// 根据key判断缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool GetExists(string key);

        /// <summary>
        /// 根据key删除缓存
        /// </summary>
        /// <param name="key"></param>
        bool Delete(string key);

        /// <summary>
        /// 设置byte[]类型缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Set(string key, byte[] value);

        /// <summary>
        /// 设置byte[]类型缓存，并设置缓存过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        bool Set(string key, byte[] value, TimeSpan ts);

        /// <summary>
        /// 设置<see cref="T"/>缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value);

        /// <summary>
        /// 设置<see cref="T"/>缓存，并设置缓存过期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        bool Set<T>(string key, T value, TimeSpan ts);

        /// <summary>
        /// 设置<see cref="object"/>缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Set(string key, object value);

        /// <summary>
        /// 设置<see cref="object"/>缓存，并设置缓存过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        bool Set(string key, object value, TimeSpan ts);
    }
}
