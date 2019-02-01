using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Titan.Blog.Infrastructure.Cache;
using Titan.Blog.Infrastructure.Log;
using Titan.Blog.Model.CommonModel.Enums;
using Titan.Blog.WebAPP.AOP;
using Titan.Blog.WebAPP.Auth.Policys;
using Titan.Blog.WebAPP.AutoMapper;
using Titan.Blog.WebAPP.Swagger;

namespace Titan.Blog.WebAPP.CoreBuilder
{
    public class TitanCoreServiceBuilder: ICoreServiceBuilder
    {
        private readonly IServiceCollection _services;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _provider;
        public TitanCoreServiceBuilder(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
            _provider = services.BuildServiceProvider();//get an instance of IServiceProvider
        }

        public void AddDbcontext()
        {
            //注入上下文对象
            //services.AddDbContext<ModelBaseContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddScoped(p => new ModelBaseContext(p.GetService<DbContextOptions<ModelBaseContext>>()));
            //services.AddScoped<IUnitOfWork,EFUnitOfWork>();//EF工作单元注入
            //services.AddScoped<ModelBaseContext>();//EF上下文注入
            //var dbbuilder = new DbContextOptionsBuilder<ModelBaseContext>()
            //.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase"));
            //             services.AddDbContext<ModelBaseContext>(options => options = dbbuilder);
            //             services.AddScoped<ModelBaseContext>((p) => { return new EcolDbContext(dbbuilder.Options); });
            //var optionsBuilder = new DbContextOptionsBuilder<ModelBaseContext>();
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //// SingleInstance 就是单例模式，现在想起来当时写的好智障
            //containerBuilder.RegisterInstance(new BookListDbContext(optionsBuilder.Options)).SingleInstance();
            //services.AddScoped<ModelBaseContext>();
        }

        public void AddMvcExtensions()
        {
            _services.AddMvc()
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore) //忽略在对象图中找到的循环引用
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void AddCache()
        {
            var cacheConfig =
                (CacheType)Enum.Parse(typeof(CacheType), _configuration.GetSection("AppSettings")["CacheType"]);
            switch (cacheConfig)
            {
                case CacheType.InMemory:
                    //net本地内存缓存
                    _services.AddScoped<ICache, Infrastructure.Cache.MemoryCache>();
                    _services.AddSingleton((Func<IServiceProvider, IMemoryCache>)(factory =>
                    {
                        var cache = new Microsoft.Extensions.Caching.Memory.MemoryCache(new MemoryCacheOptions());
                        return cache;
                    }));
                    break;
                case CacheType.Redis:
                    //redis 分布式缓存
                    _services.AddScoped<ICache, RedisCache>();
                    //autofac单例模式不能重连对象，只能自定义个类实现单例
                    //services.AddSingleton<ConnectionMultiplexer>(provider =>
                    //{
                    //    var connection= ConnectionMultiplexer.Connect(Appsettings.app(new string[] { "AppSettings", "RedisCaching", "ConnectionString" }));
                    //    return connection;
                    //});
                    break;
            }
        }

        public void AddLog()
        {
            _services.AddSingleton<ILoggerHelper, LogHelper>();
        }

        public void AddAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CustomProfile>();
            });

            _services.AddAutoMapper();
        }

        public void AddCors()
        {
            _services.AddCors(c =>
            {
                //↓↓↓↓↓↓↓注意正式环境不要使用这种全开放的处理↓↓↓↓↓↓↓↓↓↓
                c.AddPolicy("AllRequests", policy =>
                {
                    policy
                        .AllowAnyOrigin()//允许任何源
                        .AllowAnyMethod()//允许任何方式
                        .AllowAnyHeader()//允许任何头
                        .AllowCredentials();//允许cookie
                });
                //↑↑↑↑↑↑↑注意正式环境不要使用这种全开放的处理↑↑↑↑↑↑↑↑↑↑

                //一般采用这种方法
                c.AddPolicy("LimitRequests", policy =>
                {
                    policy
                        .WithOrigins("http://127.0.0.1:1818", "http://localhost:8080", "http://localhost:8021", "http://localhost:8081", "http://localhost:1818")//支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                        .AllowAnyHeader()//Ensures that the policy allows any header.
                        .AllowAnyMethod();
                });
            });
        }

        public void AddSwaggerGenerator()
        {
            _services.AddScoped<SwaggerGenerator>();//GetSwagger获取swagger.json的核心代码在这里面，这里我们用ioc容器存储对象，后面直接调里面的获取json的方法。
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            _services.AddSwaggerGen(c =>
            {
                //遍历出全部的版本，做文档信息展示
                typeof(CustomApiVersion.ApiVersions).GetEnumNames().ToList().ForEach(version =>
                {
                    c.SwaggerDoc(version, new Info
                    {
                        Version = version,
                        Title = $"{(_configuration.GetSection("Swagger"))["ProjectName"]} WebAPI",
                        Description = $"{(_configuration.GetSection("Swagger"))["ProjectName"]} HTTP WebAPI " + version + "，博客系统前后端分离，后端框架。",
                        TermsOfService = "None",
                        Contact = new Contact { Name = "韩俊俊", Email = "1454055505@qq.com", Url = "http://gaobili.cn/" }
                    });
                });
                var xmlPath1 = Path.Combine(basePath, "Titan.Blog.WebAPP.xml");//这个就是刚刚配置的xml文件名
                c.IncludeXmlComments(xmlPath1, true);//默认的第二个参数是false，这个是controller的注释，记得修改
                var xmlPath2 = Path.Combine(basePath, "Titan.Blog.AppService.xml");//这个就是Model层的xml文件名
                c.IncludeXmlComments(xmlPath2);
                var xmlPath3 = Path.Combine(basePath, "Titan.Blog.Model.xml");//这个就是Model层的xml文件名
                c.IncludeXmlComments(xmlPath3);

                #region Token绑定到ConfigureServices
                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                // 发行人
                var issuerName = (_configuration.GetSection("Audience"))["Issuer"];
                var security = new Dictionary<string, IEnumerable<string>> { { issuerName, new string[] { } }, };
                c.AddSecurityRequirement(security);

                //方案名称“Blog.WebAPP”可自定义，上下一致即可
                c.AddSecurityDefinition(issuerName, new ApiKeyScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer token（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = "header",//jwt默认存放Authorization信息的位置(请求头中)
                    Type = "apiKey"
                });
                #endregion

                #region Swagger参数自定义
                c.OperationFilter<SwaggerUploadFileFilter>();//文件上传参数
                #endregion

                #region Swagger文档过滤
                c.DocumentFilter<RemoveBogusDefinitionsDocumentFilter>();//过滤model
                #endregion

            });
        }

        public void AddJwtAuth()
        {
            //读取配置文件
            var audienceConfig = _configuration.GetSection("Audience");
            var symmetricKeyAsBase64 = audienceConfig["Secret"];
            var keyByteArray = System.Text.Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            // 令牌验证参数
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Issuer"],//发行人
                ValidateAudience = true,
                ValidAudience = audienceConfig["Audience"],//订阅人
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                RequireExpirationTime = true,

            };
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

            // 注意使用RESTful风格的接口会更好，因为只需要写一个Url即可，比如：/api/values 代表了Get Post Put Delete等多个。
            // 如果想写死，可以直接在这里写。
            //var permission = new List<Permission> {
            //                  new Permission {  Url="/api/values", Role="Admin"},
            //                  new Permission {  Url="/api/values", Role="System"},
            //                  new Permission {  Url="/api/claims", Role="Admin"},
            //              };

            // 如果要数据库动态绑定，这里先留个空，后边处理器里动态赋值
            var permission = new List<Permission>();

            // 角色与接口的权限要求参数
            var permissionRequirement = new PermissionRequirement(
                "/api/denied", // 拒绝授权的跳转地址（目前无用）
                permission,
                ClaimTypes.Role, //基于角色的授权
                audienceConfig["Issuer"], //发行人
                audienceConfig["Audience"], //听众
                signingCredentials, //签名凭据
                expiration: TimeSpan.FromSeconds(60 * 60) //接口的过期时间单位秒，1分钟*60=1小时
            );

            //加载角色策略 一个策略对应多个角色，一个角色可以对应多个策略，一个人可以有多个角色
            _services.AddAuthorization(options =>
            {
                options.AddPolicy("Client",
                    policy => policy.RequireRole("Client").Build());
                options.AddPolicy("Admin",
                    policy => policy.RequireRole("Admin").Build());
                options.AddPolicy("SystemOrAdmin",
                    policy => policy.RequireRole("Admin", "System"));

                // 自定义权限要求--使用自定义的拦截器进行权限认证
                options.AddPolicy("Permission",
                         policy => policy.Requirements.Add(permissionRequirement));
            })
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = tokenValidationParameters;
                //o.TokenValidationParameters = new TokenValidationParameters
                //{
                //    ValidateIssuer = true,//是否验证Issuer
                //    ValidateAudience = true,//是否验证Audience 
                //    ValidateIssuerSigningKey = true,//是否验证IssuerSigningKey 
                //    ValidIssuer = "Blog.Core",
                //    ValidAudience = "wr",
                //    ValidateLifetime = true,//是否验证超时  当设置exp和nbf时有效 同时启用ClockSkew 
                //    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtHelper.secretKey)),
                //    //注意这是缓冲过期时间，总的有效时间等于这个时间加上jwt的过期时间
                //    ClockSkew = TimeSpan.FromSeconds(30)

                //};
            });
            //自定义授权策略拦截器 -- 处理自定义策略的角色访问权限
            _services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
            _services.AddSingleton(permissionRequirement);
        }

        public void AddHttpContext()
        {
            _services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//httpcontext上下文
        }

        public IServiceProvider AddIocContainer()
        {
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
            //实例化 AutoFac  容器   
            var builder = new ContainerBuilder();
            builder.RegisterType<BlogCacheAOP>();
            builder.Populate(_services);
            //获取当前应用程序加载程序集（C/S应用中使用）
            //var assembly = Assembly.GetExecutingAssembly();
            //builder.RegisterAssemblyTypes(assembly); //注册所有程序集类定义的非静态类型
            builder.RegisterType<Permission>();
            builder.RegisterType<SigningCredentials>();
            var repositoryDllFile = Path.Combine(basePath, "Titan.Blog.Repository.dll");
            var assemblysRepository = Assembly.LoadFile(repositoryDllFile);//Assembly.Load("Titan.Blog.Repository");
            //var assemblysRepository = Assembly.Load("Titan.Blog.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository).Where(x => x.Name.Contains("Repository")).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(assemblysRepository).Where(x => x.Name == "ModelBaseContext").InstancePerLifetimeScope();//注册ef上下文，这里是同一个请求，也就是同一个线程内，保证ef上下文唯一

            var servicesDllFile = Path.Combine(basePath, "Titan.Blog.AppService.dll");//获取项目绝对路径
            var assemblysServices = Assembly.LoadFile(servicesDllFile);
            // Assembly.Load("Titan.Blog.AppService");//直接采用加载文件的方法
            //var assemblysServices =  Assembly.Load("Titan.Blog.AppService");//直接采用加载文件的方法
            builder.RegisterAssemblyTypes(assemblysServices)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .EnableInterfaceInterceptors()
                .InterceptedBy(typeof(BlogCacheAOP));//AOP切面缓存

            //builder.RegisterType(typeof(IBaseRepository<,>)).InstancePerDependency();//注册仓储泛型

            //builder.RegisterAssemblyTypes(assemblysServices)
            //    .EnableClassInterceptors()
            //    // 如果你想注入两个，就这么写  InterceptedBy(typeof(BlogCacheAOP), typeof(BlogLogAOP));
            //    .InterceptedBy(typeof(BlogCacheAOP));//指定已扫描程序集中的类型注册为提供所有其实现的接口。.InstancePerRequest()

            var assemblysModel = Assembly.Load("Titan.Blog.Model");//直接采用加载文件的方法
            builder.RegisterAssemblyTypes(assemblysModel).Where(x => x.Name == "ModelBaseContext").InstancePerLifetimeScope();//指定已扫描程序集中的类型注册为提供所有其实现的接口。.InstancePerRequest()

            //var assemblysInfrastru = Assembly.Load("Titan.Blog.Infrastructure");//直接采用加载文件的方法
            //builder.RegisterAssemblyTypes(assemblysInfrastru);//指定已扫描程序集中的类型注册为提供所有其实现的接口。.InstancePerRequest()

            ////builder.RegisterAssemblyTypes(assemblysServices)
            ////         .AsImplementedInterfaces()
            ////         .InstancePerLifetimeScope()
            ////         .EnableInterfaceInterceptors()//引用Autofac.Extras.DynamicProxy;
            ////         .InterceptedBy(typeof(BlogCacheAOP));//允许将拦截器服务的列表分配给注册。可以直接替换其他拦截器

            //var infrastructureDllFile = Path.Combine(basePath, "Titan.Blog.Infrastructure.dll");//获取项目绝对路径
            //var assemblysInfrastructure = Assembly.LoadFile(infrastructureDllFile);//直接采用加载文件的方法
            //builder.RegisterAssemblyTypes(assemblysInfrastructure).AsSelf();//指定已扫描程序集中的类型注册为提供所有其实现的接口。

            //var modelDllFile = Path.Combine(basePath, "Titan.Blog.Model.dll");//获取项目绝对路径
            //var assemblysModel = Assembly.LoadFile(modelDllFile);//直接采用加载文件的方法
            //builder.RegisterAssemblyTypes(assemblysModel).AsSelf();//指定已扫描程序集中的类型注册为提供所有其实现的接口。



            //var aa = Path.Combine(basePath, "Titan.Blog.WebAPP.dll");
            //var bb = Assembly.LoadFile(aa);
            //builder.RegisterAssemblyTypes(bb);

            //使用已进行的组件登记创建新容器
            var applicationContainer = builder.Build();
            //获取容器内的对象
            //var data = applicationContainer.ComponentRegistry.Registrations
            //    .Where(x => x.Activator.LimitType.ToString().Contains("Titan.RepositoryCode")).ToList();
            //var dataf = applicationContainer.ComponentRegistry.Registrations
            //    .Where(x => x.Activator.LimitType.ToString().Contains("Titan.Blog.AppService")).ToList();
            //var data1 = applicationContainer.ComponentRegistry.Registrations
            //    .Where(x => x.Activator.LimitType.ToString().Contains("BaseRepository")).ToList();
            var fff = applicationContainer.ComponentRegistry.Registrations
                .Where(x => x.Activator.LimitType.ToString().Contains("ModelBaseContext")).ToList();
            //var clas1 = applicationContainer.Resolve<AuthorDomainSvc>();
            //Console.WriteLine(clas1.GetList());
            //var efdb= applicationContainer.ResolveOptional<ModelBaseContext>();
            //var efdb1 = applicationContainer.Resolve<ModelBaseContext>();

            return new AutofacServiceProvider(applicationContainer);//第三方IOC接管 core内置DI容器
        }

        
    }
}
