/************************************************************************
 * 文件名：ModelRespositoryFactory
 * 文件功能描述：对象处理器工厂
 * 作    者：hjj
 * 创建日期：2017-06-15
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2016 Titan.Han . All Rights Reserved. 
 * ***********************************************************************/
using Titan.Model;
using Titan.RepositoryCode.Respositorys;

namespace Titan.RepositoryCode
{
    public class ModelRespositoryFactory<T, EntityKey> : RespositoryBase<T, EntityKey>
         where T : IAggregateRoot, new()
    {

        //添加公共处理类
    }
}