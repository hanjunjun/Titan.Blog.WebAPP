# Titan.Blog.WebAPP
ASP.NET Core 2.2 前后端分离、后端框架，这个项目本人会长期维护下去。

# Demo 演示地址：http://gaobili.cn:8600/swagger/index.html

# 博客园地址：https://www.cnblogs.com/hjjblog

![Logo](https://github.com/HanJunJun/Titan.Blog.WebAPP/blob/master/Titan.Blog.WebAPP/Titan.Blog.WebAPP/wwwroot/demo.png)

# 角色授权设计：

![Logo](https://github.com/HanJunJun/Titan.Blog.WebAPP/blob/master/Titan.Blog.WebAPP/Titan.Blog.WebAPP/wwwroot/%E6%9D%83%E9%99%90%E7%B3%BB%E7%BB%9F%E8%AE%BE%E8%AE%A1%E5%9B%BE.png)


# Tips：

	开发及部署环境：
	
      微软全家桶（windows 10、Visual Studio 2017、Windows Server 2008 R2、SQL server 2014、.NET Core SDK2.2）

    后端技术：
	
      * ASP.NET Core 2.2 WebAPI
	  
	  * API统一接口入参，返回值，全局异常拦截封装
      
      * Swagger API文档生成、调试、API版本管理，API基于Restful风格编写接口
	  
      * Async和Await异步编程

      * Cors .NET Core自带的全局跨域解决方案

      * Autofac 轻量级IOC容器组件

      * Redis 轻量级分布式缓存
	  
	  * JWT Token身份认证
	  
	  * ASP.NET Core Authorization 自定义授权策略（可以给API接口进行角色权限配置，详情请查阅微软.NetCore开发文档）
	  
	  * Log4Net日志组件
	  
	  * T4代码生成器
	  
	  * Quartz.Net 内置调度任务组件（待开发）   https://github.com/quartznet/quartznet 
	  
	  * SignalR 内置消息提醒非轮询 （待开发）
	  
	数据库相关：
		
	  * AOP缓存 （待开发）
	
	  * Repository + DomainService 仓储模式编程、IRepository + IDomainService解耦 （可以动态替换掉ORM 待开发）
	  
	  * Entity Framework Core 2.2 轻量级ORM框架

	  * AutoMapper 自动对象映射组件
	  
	  * Lambda、Linq、SQL
	  
	  * EntityFramework反向POCO代码生成器
	  （这个插件不支持.NetCore和EFCore，需要改写作者的代码，有空的可以研究下这个组件）  https://github.com/sjh37/EntityFramework-Reverse-POCO-Code-First-Generator  
	  
	前端技术：
	
	  * Vue 2.0全家桶（Vue2 + VueRouter2 + Webpack + Axios）
	  
	  * ElementUI 基于Vue 2.0的前端UI组件库
	  （前端目前还在学习中。）
	  
# 开发计划：
	
	1.Swagger 导出API文档到Word、PDF、Html。--2019-01-06 已完成
	2.Swagger 后台返回图像，前端显示图像。
	3.接口加频率限制，超出频率提示验证码。
	4.IP黑名单过滤。
	5.EF Core 仓储模式重构。
	6.AOP缓存实现
	7.短信接口
	8.微信集成
	9.开源项目分支：EF Core POCO 代码生成器，使用RazorEngine MVC模板引擎实现，支持DBFirst和CodeFirst
	10.内置任务调度服务
	11.内置消息推送服务
	