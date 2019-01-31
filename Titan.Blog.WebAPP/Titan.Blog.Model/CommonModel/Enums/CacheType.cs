/************************************************************************
 * 文件名：CacheType
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/31 14:30:54
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Blog.Model.CommonModel.Enums
{
    public enum CacheType
    {
        /// <summary>
        /// .Net Core 自带缓存
        /// </summary>
        InMemory,
        /// <summary>
        /// Redis 分布式缓存
        /// </summary>
        Redis
    }
}
