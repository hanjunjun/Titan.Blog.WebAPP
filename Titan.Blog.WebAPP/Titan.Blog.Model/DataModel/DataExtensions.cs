/************************************************************************
 * 文件名：DataExtensions
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2018/12/24 16:35:30
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 南京索酷信息科技有限公司. All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Titan.Model.DataModel;

namespace Titan.Blog.Model.DataModel
{
    public interface IEntityTypeConfiguration
    {
    }
    public class SysCompanyConfiguration : IEntityTypeConfiguration
    {
        public SysCompanyConfiguration(ModelBuilder builder)
        {
            builder.Entity<SysCompany>().ToTable("SysCompany");
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void ExecuteConfigurations(this ModelBuilder modelBuilder, string assemblyName)
        {
            var configurationTypes = Assembly.Load(new AssemblyName(assemblyName)).GetTypes()
                .Where(type => !string.IsNullOrWhiteSpace(type.Namespace))
                .Where(type => type.GetTypeInfo().IsClass)
                .Where(type => type.GetTypeInfo().BaseType != null)
                .Where(type => typeof(IEntityTypeConfiguration).IsAssignableFrom(type))
                .ToList();

            foreach (var type in configurationTypes)
                Activator.CreateInstance(type, modelBuilder);
        }
    }
}
