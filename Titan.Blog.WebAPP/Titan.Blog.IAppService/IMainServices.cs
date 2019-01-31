/************************************************************************
 * 文件名：IMainServices
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/22 17:13:34
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Titan.Blog.IAppService.Base;
using Titan.Blog.Model.CommonModel.ResultModel;
using Titan.Blog.Model.DataModel;
using Titan.Blog.Model.DTOModel;

namespace Titan.Blog.IAppService
{
    public interface IMainServices:IBaseServices<Main,Guid>
    {
        Task AddModel(Main model);
        Task<Tuple<List<Main>, int>> GetList();

        Task<Tuple<List<Children>, int>> QueryAsNotraking();
        Task<List<SysRoleModuleButtonDto>> GeRoleModule();
        Task<Tuple<OpResult<string>, SysUser>> VerifyPassword(string userId, string userPwd);
    }
}
