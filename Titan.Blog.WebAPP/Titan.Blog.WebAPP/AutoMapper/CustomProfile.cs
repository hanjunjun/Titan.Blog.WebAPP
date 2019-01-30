using AutoMapper;
using Titan.Blog.Model.DataModel;
using Titan.Blog.Model.DTOModel;

namespace Titan.Blog.WebAPP.AutoMapper
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            CreateMap<SysRoleModuleButton, SysRoleModuleButtonDto>();
            CreateMap<SysUser, SysUserDto>();
        }
    }
}
