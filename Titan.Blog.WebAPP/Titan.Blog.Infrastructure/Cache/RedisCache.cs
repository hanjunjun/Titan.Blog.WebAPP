using System;
using StackExchange.Redis;
using Titan.Blog.Infrastructure.Serializable;
using Titan.Blog.Infrastructure.Utility;

namespace Titan.Blog.Infrastructure.Cache
{
    public class RedisCache : ICache
    {
       
        private static string _redisConnenctionString;

        private static ConnectionMultiplexer RedisConnection;

        private static readonly object MLock = new object();//全局锁

        public RedisCache()
        {
            if (string.IsNullOrEmpty(_redisConnenctionString))
            {
                string redisConfiguration = Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString" });//获取连接字符串
                if (string.IsNullOrWhiteSpace(redisConfiguration))
                {
                    throw new ArgumentException("redis config is empty!", nameof(redisConfiguration));
                }
                _redisConnenctionString = redisConfiguration;
            }
            RedisConnection = GetRedisConnection();
        }

        /// <summary>
        /// 核心代码，获取连接实例
        /// 通过双if 夹lock的方式，实现单例模式
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer GetRedisConnection()
        {
            //如果已经连接实例，直接返回
            if (RedisConnection != null && RedisConnection.IsConnected)
            {
                return RedisConnection;
            }
            //加锁，防止异步编程中，出现单例无效的问题
            lock (MLock)
            {
                if (RedisConnection != null && RedisConnection.IsConnected)
                {
                    return RedisConnection;
                }
                else
                {
                    if (RedisConnection != null)
                    {
                        //释放redis连接
                        RedisConnection.Dispose();
                    }
                    RedisConnection = ConnectionMultiplexer.Connect(_redisConnenctionString);
                }
            }
            return RedisConnection;
        }

        /// <summary>
        /// 根据key判断缓存是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool GetExists(string key)
        {
            return RedisConnection.GetDatabase().KeyExists(key);
        }

        /// <summary>
        /// 根据key获取缓存字符串数据
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            return RedisConnection.GetDatabase().StringGet(key);
        }

        /// <summary>
        /// 根据key获取缓存实体数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {
            var value = RedisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将Redis存储的Byte[]，进行反序列化
                return JsonHelper.StrToModel<T>(value);
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
            return RedisConnection.GetDatabase().KeyDelete(key);
        }

        /// <summary>
        /// 设置byte[]类型缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Set(string key, byte[] value)
        {
            return RedisConnection.GetDatabase().StringSet(key, value);
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
            return RedisConnection.GetDatabase().StringSet(key, value, ts);
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
                return RedisConnection.GetDatabase().StringSet(key, JsonHelper.ModelToBytes(value));
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
        public bool Set<T>(string key, T value,TimeSpan ts)
        {
            if (value != null)
            {
                return RedisConnection.GetDatabase().StringSet(key, JsonHelper.ModelToBytes(value), ts);
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
                return RedisConnection.GetDatabase().StringSet(key, JsonHelper.ModelToBytes(value));
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
                return RedisConnection.GetDatabase().StringSet(key, JsonHelper.ModelToBytes(value), ts);
            }
            else
            {
                throw new Exception($"{default(object)}不能为null！");
            }
        }
    }
}
