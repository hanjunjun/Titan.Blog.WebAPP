using System;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Newtonsoft.Json;
using Titan.Blog.Infrastructure.Attribute;
using Titan.Blog.Infrastructure.Redis;

namespace Titan.Blog.WebAPP.AOP
{
    /// <summary>
    /// 面向切面的缓存使用
    /// </summary>
    public class BlogCacheAOP : IInterceptor
    {
        //通过注入的方式，把缓存操作接口通过构造函数注入
        //private ICaching _cache;
        private IRedisCacheManager _redisCache;
        public BlogCacheAOP(/*ICaching cache,*/ IRedisCacheManager redisCache)
        {
            //_cache = cache;
            _redisCache = redisCache;
        }
        //Intercept方法是拦截的关键所在，也是IInterceptor接口中的唯一定义
        public void Intercept(IInvocation invocation)
        {
            var method = invocation.MethodInvocationTarget ?? invocation.Method;
            //对当前方法的特性验证
            var qCachingAttribute = method.GetCustomAttributes(true).FirstOrDefault(x => x.GetType() == typeof(CachingAttribute)) as CachingAttribute;
            //如果需要验证
            if (qCachingAttribute != null)
            {
                CacheIntercept(invocation, qCachingAttribute);
            }
            else
            {
                invocation.Proceed();//直接执行被拦截方法
            }
        }

        private void CacheIntercept(IInvocation invocation, CachingAttribute cacheAttribute)
        {
            //获取自定义缓存键
            var cacheKey = CustomCacheKey(invocation);
            var cacheValue = _redisCache.Get(cacheKey);
            //判断redis中是否存在值
            if (cacheValue)
            {
                //将当前获取到的缓存值，赋值给当前执行方法
                var type = invocation.Method.ReturnType;
                var resultTypes = type.GenericTypeArguments;
                if (type.FullName == "System.Void")
                {
                    return;
                }
                object response;
                if (type != null && typeof(Task).IsAssignableFrom(type))
                {
                    //返回Task<T>
                    if (resultTypes.Any())
                    {
                        var resultType = resultTypes.FirstOrDefault();
                        var data = _redisCache.GetValue(cacheKey);
                        dynamic temp = JsonConvert.DeserializeObject(data, resultType);
                        //dynamic temp = System.Convert.ChangeType(cacheValue, resultType);
                        // System.Convert.ChangeType(Task.FromResult(temp), type);
                        response = Task.FromResult(temp);
                    }
                    else
                    {
                        //Task 无返回方法 指定时间内不允许重新运行
                        response = Task.Yield();
                    }
                }
                else
                {
                    //var data = _redisCache.Get<object>(cacheKey);
                    //response = System.Convert.ChangeType(data, type);
                    var data = _redisCache.GetValue(cacheKey);
                    dynamic temp = JsonConvert.DeserializeObject(data, type);//不存task返回类型就直接用返回类型反序列化
                    response = System.Convert.ChangeType(temp, type);
                }

                invocation.ReturnValue = response;
                return;
            }
            //去执行当前的方法
            invocation.Proceed();

            //存入缓存
            if (!string.IsNullOrWhiteSpace(cacheKey))
            {
                object response;

                //Type type = invocation.ReturnValue?.GetType();
                var type = invocation.Method.ReturnType;
                if (type != null && typeof(Task).IsAssignableFrom(type))
                {
                    var resultProperty = type.GetProperty("Result");
                    response = resultProperty.GetValue(invocation.ReturnValue);
                }
                else
                {
                    response = invocation.ReturnValue;
                }
                if (response == null) response = string.Empty;
                _redisCache.Set(cacheKey, response, cacheAttribute.AbsoluteExpiration);
            }
        }

        //自定义缓存键
        private string CustomCacheKey(IInvocation invocation)
        {
            var typeName = invocation.TargetType.Name;
            var methodName = invocation.Method.Name;
            var methodArguments = invocation.Arguments.Select(GetArgumentValue).Take(3).ToList();//获取参数列表，最多三个

            string key = $"{typeName}:{methodName}:";
            foreach (var param in methodArguments)
            {
                key += $"{param}:";
            }

            return key.TrimEnd(':');
        }
        //object 转 string
        private string GetArgumentValue(object arg)
        {
            if (arg is int || arg is long || arg is string)
                return arg.ToString();

            if (arg is DateTime)
                return ((DateTime)arg).ToString("yyyyMMddHHmmss");

            return "";
        }
    }

}
