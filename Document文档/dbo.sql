/*
Navicat SQL Server Data Transfer

Source Server Version : 120000
Source Database       : TestDB
Source Schema         : dbo

Target Server Type    : SQL Server
Target Server Version : 120000
File Encoding         : 65001

Date: 2019-01-07 14:36:38
*/


-- ----------------------------
-- Table structure for SysButton
-- ----------------------------
DROP TABLE [dbo].[SysButton]
GO
CREATE TABLE [dbo].[SysButton] (
[SysButtonId] uniqueidentifier NOT NULL ,
[SysModuleId] uniqueidentifier NULL ,
[ButtonCode] int NULL ,
[ButtonName] varchar(40) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysButton', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'按钮表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'按钮表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysButton', 
'COLUMN', N'SysButtonId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'按钮表Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
, @level2type = 'COLUMN', @level2name = N'SysButtonId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'按钮表Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
, @level2type = 'COLUMN', @level2name = N'SysButtonId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysButton', 
'COLUMN', N'SysModuleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'API和模块Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
, @level2type = 'COLUMN', @level2name = N'SysModuleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'API和模块Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
, @level2type = 'COLUMN', @level2name = N'SysModuleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysButton', 
'COLUMN', N'ButtonCode')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'按钮代号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
, @level2type = 'COLUMN', @level2name = N'ButtonCode'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'按钮代号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
, @level2type = 'COLUMN', @level2name = N'ButtonCode'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysButton', 
'COLUMN', N'ButtonName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'按钮名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
, @level2type = 'COLUMN', @level2name = N'ButtonName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'按钮名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysButton'
, @level2type = 'COLUMN', @level2name = N'ButtonName'
GO

-- ----------------------------
-- Records of SysButton
-- ----------------------------

-- ----------------------------
-- Table structure for SysModule
-- ----------------------------
DROP TABLE [dbo].[SysModule]
GO
CREATE TABLE [dbo].[SysModule] (
[SysModuleId] uniqueidentifier NOT NULL ,
[ModuleName] varchar(50) NULL ,
[LinkUrl] varchar(200) NULL ,
[Controller] varchar(100) NULL ,
[Action] varchar(100) NULL ,
[ModuleStatus] bit NULL ,
[Sort] int NULL ,
[ParentId] uniqueidentifier NULL ,
[ModuleIcon] varchar(200) NULL ,
[IsDelete] bit NULL ,
[ModuleDesc] varchar(400) NULL ,
[ModuleType] int NULL ,
[SysUserId] uniqueidentifier NULL ,
[UserName] varchar(100) NULL ,
[CreateTime] datetime NULL ,
[ModifyId] uniqueidentifier NULL ,
[ModifyByName] varchar(100) NULL ,
[ModifyTime] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'API和模块表存储api接口和模块'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'API和模块表存储api接口和模块'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'SysModuleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'API和模块表Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'SysModuleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'API和模块表Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'SysModuleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ModuleName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模块名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模块名称'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'LinkUrl')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'API或模块地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'LinkUrl'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'API或模块地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'LinkUrl'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'Controller')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'控制器'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'Controller'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'控制器'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'Controller'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'Action')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'方法'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'Action'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'方法'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'Action'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ModuleStatus')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否启用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleStatus'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否启用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleStatus'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'Sort')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'Sort'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'排序'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'Sort'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ParentId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'父Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ParentId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'父Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ParentId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ModuleIcon')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模块图标'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleIcon'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模块图标'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleIcon'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'IsDelete')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'IsDelete'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'IsDelete'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ModuleDesc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleDesc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleDesc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ModuleType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否模块（0：api 1：模块）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否模块（0：api 1：模块）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModuleType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'SysUserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'UserName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'UserName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'UserName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ModifyId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModifyId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModifyId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ModifyByName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModifyByName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModifyByName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysModule', 
'COLUMN', N'ModifyTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModifyTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysModule'
, @level2type = 'COLUMN', @level2name = N'ModifyTime'
GO

-- ----------------------------
-- Records of SysModule
-- ----------------------------
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'67C1AC1E-1448-4F6C-A835-C12D66CE0DAC', N'超级管理员2', N'/api/v2/ImageTest/EFCoreTest', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'A44DEA54-FE72-4C27-BF40-5A624975D982', N'超管2指定数量文件上传', N'/api/v2/FileTest/UploadFile', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'4D41C4D6-44D3-469F-8491-2F3C82BB786D', N'多文件上传', N'/api/v2/FileTest/UploadFileList', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'9DC2891B-B39E-44F5-B2E1-CF2CCF4BF4EB', N'文件下载', N'/api/v2/FileTest/DownloadFile', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'E20EFD23-5ECA-4686-8D64-4A194C183459', N'管理员1', N'/api/v2/Test/ArrayTest', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'45482BF8-EE56-4B86-AC59-51230C0BE672', null, N'/api/v2/Test/BlogList', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'FDE54D4D-9FB2-424C-970E-CDE496A52650', N'普通用户0', N'/api/v2/Test/AddBlog', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'FB66445A-B4B4-4D4B-9CD7-C8CB7160DB02', null, N'/api/v2/Test/UpdateBlog', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'F433AB0E-786A-494E-BA13-F857D6720BF3', null, N'/api/v2/Test/DeleteBlog', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'13C3EA8A-013C-4995-8D29-A48237C0BADA', null, N'/api/v2/Test/HiddenTest', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'583299A9-634C-4A88-86D8-1784A530EC34', null, N'/api/v2/Test/FormHeader', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'49F6C83B-988E-4B84-8C4E-97445884CDC1', null, N'/api/v1/Authorization/LoginV1', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysModule] ([SysModuleId], [ModuleName], [LinkUrl], [Controller], [Action], [ModuleStatus], [Sort], [ParentId], [ModuleIcon], [IsDelete], [ModuleDesc], [ModuleType], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'70F3775C-513C-48FB-85AC-9C45944A0EB4', null, N'/api/v1/Authorization/Test', null, null, N'1', null, null, null, N'0', null, N'0', null, null, null, null, null, null)
GO
GO

-- ----------------------------
-- Table structure for SysOperateLog
-- ----------------------------
DROP TABLE [dbo].[SysOperateLog]
GO
CREATE TABLE [dbo].[SysOperateLog] (
[SysOperateLogId] uniqueidentifier NOT NULL ,
[Controller] varchar(100) NULL ,
[Action] varchar(100) NULL ,
[LinkUrl] varchar(200) NULL ,
[IPAddress] varchar(50) NULL ,
[OperateTime] datetime NULL ,
[SysUserId] uniqueidentifier NULL ,
[UserName] varchar(100) NULL ,
[OperateDesc] varchar(400) NULL ,
[OperateType] int NULL ,
[BusinessId] uniqueidentifier NULL ,
[IsDelete] bit NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作记录'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作记录'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'SysOperateLogId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作记录Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'SysOperateLogId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作记录Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'SysOperateLogId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'Controller')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'控制器'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'Controller'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'控制器'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'Controller'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'Action')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'方法'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'Action'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'方法'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'Action'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'LinkUrl')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'API或模块地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'LinkUrl'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'API或模块地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'LinkUrl'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'IPAddress')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'IP地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'IPAddress'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'IP地址'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'IPAddress'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'OperateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'OperateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'OperateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'SysUserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'UserName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'UserName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'UserName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'OperateDesc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'OperateDesc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'OperateDesc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'OperateType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'操作动作（0：登录 1：增 2：删 3：改 4：查）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'OperateType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'操作动作（0：登录 1：增 2：删 3：改 4：查）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'OperateType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'BusinessId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'业务Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'BusinessId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'业务Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'BusinessId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysOperateLog', 
'COLUMN', N'IsDelete')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'IsDelete'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysOperateLog'
, @level2type = 'COLUMN', @level2name = N'IsDelete'
GO

-- ----------------------------
-- Records of SysOperateLog
-- ----------------------------

-- ----------------------------
-- Table structure for SysRole
-- ----------------------------
DROP TABLE [dbo].[SysRole]
GO
CREATE TABLE [dbo].[SysRole] (
[SysRoleId] uniqueidentifier NOT NULL ,
[RoleName] varchar(40) NULL ,
[RoleDesc] varchar(400) NULL ,
[RoleStatus] bit NULL ,
[IsDelete] bit NULL ,
[SysUserId] uniqueidentifier NULL ,
[UserName] varchar(100) NULL ,
[CreateTime] datetime NULL ,
[ModifyId] uniqueidentifier NULL ,
[ModifyByName] varchar(100) NULL ,
[ModifyTime] datetime NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色表'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'SysRoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'SysRoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'SysRoleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'RoleName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'RoleName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'RoleName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'RoleDesc')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'RoleDesc'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'备注'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'RoleDesc'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'RoleStatus')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否启用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'RoleStatus'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否启用'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'RoleStatus'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'IsDelete')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'IsDelete'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否删除'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'IsDelete'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'SysUserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'UserName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'UserName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'UserName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'CreateTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'创建时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'CreateTime'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'ModifyId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'ModifyId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改人Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'ModifyId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'ModifyByName')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'ModifyByName'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改人姓名'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'ModifyByName'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRole', 
'COLUMN', N'ModifyTime')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'ModifyTime'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'修改时间'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRole'
, @level2type = 'COLUMN', @level2name = N'ModifyTime'
GO

-- ----------------------------
-- Records of SysRole
-- ----------------------------
INSERT INTO [dbo].[SysRole] ([SysRoleId], [RoleName], [RoleDesc], [RoleStatus], [IsDelete], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'A6F8C57E-4DC4-4837-8630-AD0139FE834C', N'SuperAdmin', N'超级管理员', N'1', N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysRole] ([SysRoleId], [RoleName], [RoleDesc], [RoleStatus], [IsDelete], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'424002A8-521D-4324-B3E0-81A51B340010', N'Admin', N'管理员', N'1', N'0', null, null, null, null, null, null)
GO
GO
INSERT INTO [dbo].[SysRole] ([SysRoleId], [RoleName], [RoleDesc], [RoleStatus], [IsDelete], [SysUserId], [UserName], [CreateTime], [ModifyId], [ModifyByName], [ModifyTime]) VALUES (N'4D4875B5-1EB8-428A-8BAA-1F938E1A4E83', N'User', N'普通用户', N'1', N'0', null, null, null, null, null, null)
GO
GO

-- ----------------------------
-- Table structure for SysRoleModuleButton
-- ----------------------------
DROP TABLE [dbo].[SysRoleModuleButton]
GO
CREATE TABLE [dbo].[SysRoleModuleButton] (
[SysRoleModuleButtonId] uniqueidentifier NOT NULL ,
[SysRoleId] uniqueidentifier NULL ,
[SysModuleId] uniqueidentifier NULL ,
[AvailableButtonJson] varchar(4000) NULL ,
[ModuleType] int NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRoleModuleButton', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色与模块、按钮关系中间表
   一个角色下有多个模块，每个模块可用按钮存这个模块有哪些按钮是可以使用的。'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色与模块、按钮关系中间表
   一个角色下有多个模块，每个模块可用按钮存这个模块有哪些按钮是可以使用的。'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRoleModuleButton', 
'COLUMN', N'SysRoleModuleButtonId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色与模块按钮关系Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'SysRoleModuleButtonId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色与模块按钮关系Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'SysRoleModuleButtonId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRoleModuleButton', 
'COLUMN', N'SysRoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'SysRoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'SysRoleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRoleModuleButton', 
'COLUMN', N'SysModuleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'模块或APIId'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'SysModuleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'模块或APIId'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'SysModuleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRoleModuleButton', 
'COLUMN', N'AvailableButtonJson')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'可用按钮Json（最大应该不会超过2000个）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'AvailableButtonJson'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'可用按钮Json（最大应该不会超过2000个）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'AvailableButtonJson'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysRoleModuleButton', 
'COLUMN', N'ModuleType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'是否模块（0：api 1：模块）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'ModuleType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'是否模块（0：api 1：模块）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysRoleModuleButton'
, @level2type = 'COLUMN', @level2name = N'ModuleType'
GO

-- ----------------------------
-- Records of SysRoleModuleButton
-- ----------------------------
INSERT INTO [dbo].[SysRoleModuleButton] ([SysRoleModuleButtonId], [SysRoleId], [SysModuleId], [AvailableButtonJson], [ModuleType]) VALUES (N'30C89D74-13DB-462B-BC8D-7A2769CC6811', N'A6F8C57E-4DC4-4837-8630-AD0139FE834C', N'67C1AC1E-1448-4F6C-A835-C12D66CE0DAC', null, N'0')
GO
GO
INSERT INTO [dbo].[SysRoleModuleButton] ([SysRoleModuleButtonId], [SysRoleId], [SysModuleId], [AvailableButtonJson], [ModuleType]) VALUES (N'3AFE44DE-E250-4903-BE46-EC0E28C94AA7', N'424002A8-521D-4324-B3E0-81A51B340010', N'E20EFD23-5ECA-4686-8D64-4A194C183459', null, N'0')
GO
GO
INSERT INTO [dbo].[SysRoleModuleButton] ([SysRoleModuleButtonId], [SysRoleId], [SysModuleId], [AvailableButtonJson], [ModuleType]) VALUES (N'A2004BA2-9275-4EEF-9EB8-5D14F9ECCDD4', N'4D4875B5-1EB8-428A-8BAA-1F938E1A4E83', N'FDE54D4D-9FB2-424C-970E-CDE496A52650', null, N'0')
GO
GO
INSERT INTO [dbo].[SysRoleModuleButton] ([SysRoleModuleButtonId], [SysRoleId], [SysModuleId], [AvailableButtonJson], [ModuleType]) VALUES (N'9EDDBD9E-C2D8-475D-9A8A-9D54F1F3771A', N'A6F8C57E-4DC4-4837-8630-AD0139FE834C', N'A44DEA54-FE72-4C27-BF40-5A624975D982', null, N'0')
GO
GO

-- ----------------------------
-- Table structure for SysUser
-- ----------------------------
DROP TABLE [dbo].[SysUser]
GO
CREATE TABLE [dbo].[SysUser] (
[SysUserId] uniqueidentifier NOT NULL ,
[UserId] varchar(100) NULL ,
[UserPwd] varchar(100) NULL ,
[UserType] int NULL ,
[UserStatus] int NULL ,
[Telphone] varchar(50) NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUser', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户表-用户信息表可以在建一个扩展表存真实姓名签名性别。'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户表-用户信息表可以在建一个扩展表存真实姓名签名性别。'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUser', 
'COLUMN', N'SysUserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUser', 
'COLUMN', N'UserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户帐号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'UserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户帐号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'UserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUser', 
'COLUMN', N'UserPwd')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'UserPwd'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户密码'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'UserPwd'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUser', 
'COLUMN', N'UserType')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户类型（0：普通用户 1：管理员 2：超级管理员）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'UserType'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户类型（0：普通用户 1：管理员 2：超级管理员）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'UserType'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUser', 
'COLUMN', N'UserStatus')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户状态（0：禁用 1：启用）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'UserStatus'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户状态（0：禁用 1：启用）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'UserStatus'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUser', 
'COLUMN', N'Telphone')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'手机号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'Telphone'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'手机号'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUser'
, @level2type = 'COLUMN', @level2name = N'Telphone'
GO

-- ----------------------------
-- Records of SysUser
-- ----------------------------
INSERT INTO [dbo].[SysUser] ([SysUserId], [UserId], [UserPwd], [UserType], [UserStatus], [Telphone]) VALUES (N'07B71543-DED0-4CB7-8E39-9964C0887992', N'0', N'0', N'0', N'1', null)
GO
GO
INSERT INTO [dbo].[SysUser] ([SysUserId], [UserId], [UserPwd], [UserType], [UserStatus], [Telphone]) VALUES (N'31F24766-7DCA-444D-A9CB-B64283AC2E82', N'1', N'1', N'1', N'1', null)
GO
GO
INSERT INTO [dbo].[SysUser] ([SysUserId], [UserId], [UserPwd], [UserType], [UserStatus], [Telphone]) VALUES (N'77BC688C-2B29-4E92-9F19-57568469105B', N'2', N'2', N'2', N'1', null)
GO
GO

-- ----------------------------
-- Table structure for SysUserRole
-- ----------------------------
DROP TABLE [dbo].[SysUserRole]
GO
CREATE TABLE [dbo].[SysUserRole] (
[SysUserRoleId] uniqueidentifier NOT NULL ,
[SysUserId] uniqueidentifier NULL ,
[SysRoleId] uniqueidentifier NULL 
)


GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUserRole', 
NULL, NULL)) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户与角色中间表（一个用户可以有多个角色）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUserRole'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户与角色中间表（一个用户可以有多个角色）'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUserRole'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUserRole', 
'COLUMN', N'SysUserRoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户与角色的关系Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUserRole'
, @level2type = 'COLUMN', @level2name = N'SysUserRoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户与角色的关系Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUserRole'
, @level2type = 'COLUMN', @level2name = N'SysUserRoleId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUserRole', 
'COLUMN', N'SysUserId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUserRole'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'用户Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUserRole'
, @level2type = 'COLUMN', @level2name = N'SysUserId'
GO
IF ((SELECT COUNT(*) from fn_listextendedproperty('MS_Description', 
'SCHEMA', N'dbo', 
'TABLE', N'SysUserRole', 
'COLUMN', N'SysRoleId')) > 0) 
EXEC sp_updateextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUserRole'
, @level2type = 'COLUMN', @level2name = N'SysRoleId'
ELSE
EXEC sp_addextendedproperty @name = N'MS_Description', @value = N'角色Id'
, @level0type = 'SCHEMA', @level0name = N'dbo'
, @level1type = 'TABLE', @level1name = N'SysUserRole'
, @level2type = 'COLUMN', @level2name = N'SysRoleId'
GO

-- ----------------------------
-- Records of SysUserRole
-- ----------------------------
INSERT INTO [dbo].[SysUserRole] ([SysUserRoleId], [SysUserId], [SysRoleId]) VALUES (N'E0DF6EF9-CD55-4458-B3E5-A90526836CA6', N'07B71543-DED0-4CB7-8E39-9964C0887992', N'4D4875B5-1EB8-428A-8BAA-1F938E1A4E83')
GO
GO
INSERT INTO [dbo].[SysUserRole] ([SysUserRoleId], [SysUserId], [SysRoleId]) VALUES (N'0ADD2F77-C9B3-4023-A180-4D85250EC827', N'31F24766-7DCA-444D-A9CB-B64283AC2E82', N'424002A8-521D-4324-B3E0-81A51B340010')
GO
GO
INSERT INTO [dbo].[SysUserRole] ([SysUserRoleId], [SysUserId], [SysRoleId]) VALUES (N'3439AAF1-7B91-4C08-9687-69F47EAC6344', N'77BC688C-2B29-4E92-9F19-57568469105B', N'A6F8C57E-4DC4-4837-8630-AD0139FE834C')
GO
GO

-- ----------------------------
-- Indexes structure for table SysButton
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SysButton
-- ----------------------------
ALTER TABLE [dbo].[SysButton] ADD PRIMARY KEY NONCLUSTERED ([SysButtonId])
GO

-- ----------------------------
-- Indexes structure for table SysModule
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SysModule
-- ----------------------------
ALTER TABLE [dbo].[SysModule] ADD PRIMARY KEY NONCLUSTERED ([SysModuleId])
GO

-- ----------------------------
-- Indexes structure for table SysOperateLog
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SysOperateLog
-- ----------------------------
ALTER TABLE [dbo].[SysOperateLog] ADD PRIMARY KEY NONCLUSTERED ([SysOperateLogId])
GO

-- ----------------------------
-- Indexes structure for table SysRole
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SysRole
-- ----------------------------
ALTER TABLE [dbo].[SysRole] ADD PRIMARY KEY NONCLUSTERED ([SysRoleId])
GO

-- ----------------------------
-- Indexes structure for table SysRoleModuleButton
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SysRoleModuleButton
-- ----------------------------
ALTER TABLE [dbo].[SysRoleModuleButton] ADD PRIMARY KEY NONCLUSTERED ([SysRoleModuleButtonId])
GO

-- ----------------------------
-- Indexes structure for table SysUser
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SysUser
-- ----------------------------
ALTER TABLE [dbo].[SysUser] ADD PRIMARY KEY NONCLUSTERED ([SysUserId])
GO

-- ----------------------------
-- Indexes structure for table SysUserRole
-- ----------------------------

-- ----------------------------
-- Primary Key structure for table SysUserRole
-- ----------------------------
ALTER TABLE [dbo].[SysUserRole] ADD PRIMARY KEY NONCLUSTERED ([SysUserRoleId])
GO
