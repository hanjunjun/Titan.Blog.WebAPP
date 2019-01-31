/************************************************************************
 * 文件名：Memory
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/31 16:08:11
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Titan.Blog.Infrastructure.Serializable;

namespace Titan.Blog.Infrastructure.Cache
{
    public class MemoryCache: ICache
    {
        private IMemoryCache _cache;
        public MemoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }
        /// <summary>
        /// 根据key判断缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool GetExists(string key)
        {
            object value=null;
            return _cache.TryGetValue(key, out value);
        }

        /// <summary>
        /// 根据key获取缓存字符串数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            string value = null;
            _cache.TryGetValue(key, out value);
            return value;
        }

        /// <summary>
        /// 根据key获取缓存实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            T value = default(T);
            if (_cache.TryGetValue<T>(key, out value))
            {
                return value;
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 根据key删除缓存
        /// </summary>
        /// <param name="key"></param>
        public bool Delete(string key)
        {
            _cache.Remove(key);
            return true;
        }

        /// <summary>
        /// 设置byte[]类型缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string key, byte[] value)
        {
            _cache.Set(key, value);
            return true;
        }

        /// <summary>
        /// 设置byte[]类型缓存，并设置缓存过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool Set(string key, byte[] value, TimeSpan ts)
        {
            _cache.Set(key, value,ts);
            return true;
        }

        /// <summary>
        /// 设置<see cref="T"/>缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value)
        {
            if (value != null)
            {
                _cache.Set(key, value);
                return true;
            }
            else
            {
                throw new Exception($"{default(T)}不能为null！");
            }
        }

        /// <summary>
        /// 设置<see cref="T"/>缓存，并设置缓存过期时间
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool Set<T>(string key, T value, TimeSpan ts)
        {
            if (value != null)
            {
                _cache.Set(key, value, ts);
                return true;
            }
            else
            {
                throw new Exception($"{default(T)}不能为null！");
            }
        }

        /// <summary>
        /// 设置<see cref="object"/>缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string key, object value)
        {
            if (value != null)
            {
                _cache.Set(key, JsonHelper.ModelToStr(value));
                return true;
            }
            else
            {
                throw new Exception($"{default(object)}不能为null！");
            }
        }

        /// <summary>
        /// 设置<see cref="object"/>缓存，并设置缓存过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="ts"></param>
        /// <returns></returns>
        public bool Set(string key, object value, TimeSpan ts)
        {
            if (value != null)
            {
                _cache.Set(key, JsonHelper.ModelToStr(value), ts);
                return true;
            }
            else
            {
                throw new Exception($"{default(object)}不能为null！");
            }
        }
    }
}
