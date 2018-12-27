# Titan.Blog.WebAPP
ASP.NET Core 2.2 前后端分离、后端框架，这个项目本人会长期维护下去。

Demo 演示地址：http://gaobili.cn:8600/swagger/index.html

![Logo](https://github.com/HanJunJun/Titan.Blog.WebAPP/blob/master/Titan.Blog.WebAPP/Titan.Blog.WebAPP/wwwroot/demo.png)


# Tips：

	开发及部署环境：
	
      微软全家桶（windows 10、Visual Studio 2017、Windows Server 2008 R2、SQL server 2014、.NET Core SDK2.2）

    后端技术：
	
      * ASP.NET Core 2.2 WebAPI
	  
	  * API统一接口入参，返回值，全局异常拦截封装（抄袭同事的 - -!）
      
      * Swagger API文档生成、调试、API版本管理，API基于Restful风格编写接口
	  
      * Async和Await异步编程

      * Cors .NET Core自带的全局跨域解决方案

      * Autofac 轻量级IOC容器组件

      * Redis 轻量级分布式缓存
	  
	  * JWT Token身份认证
	  
	  * ASP.NET Core Authorization 自定义授权策略（可以给API接口进行角色权限配置，详情请查阅微软.NetCore开发文档）
	  
	  * Log4Net日志组件
	  
	  * T4代码生成器
	  
	  * Quartz.Net 调度任务组件   https://github.com/quartznet/quartznet
	  
	数据库相关：
	
	  * Repository + DomainService 仓储模式编程 （借鉴同事的 - -!）
	  
	  * Entity Framework Core 2.2 轻量级ORM框架

	  * AutoMapper 自动对象映射组件
	  
	  * Lambda、Linq、SQL
	  
	  * EntityFramework反向POCO代码生成器
	  （这个插件不支持.NetCore和EFCore，需要改写作者的代码，有空的可以研究下这个组件）  https://github.com/sjh37/EntityFramework-Reverse-POCO-Code-First-Generator  
	  
	前端技术：
	
	  * Vue 2.0全家桶（Vue2 + VueRouter2 + Webpack + Axios）
	  
	  * ElementUI 基于Vue 2.0的前端UI组件库
	  （前端目前还在学习中。）