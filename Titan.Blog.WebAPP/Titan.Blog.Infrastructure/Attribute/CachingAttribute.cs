using System;

namespace Titan.Blog.Infrastructure.Attribute
{
    /// <summary>
    /// 标记这个特性的方法，它的执行结果将会存入Redis缓存中
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CachingAttribute : System.Attribute
    {
        /// <summary>
        /// 缓存过期时间累加值（单位：分钟）
        /// 当前时间+缓存过期累加值=过期时间
        /// </summary>
        public int AbsoluteExpiration { get; set; } = 30;

    }
}
