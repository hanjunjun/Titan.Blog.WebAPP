/************************************************************************
 * 文件名：MainServices
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/22 17:25:45
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Titan.Blog.AppService.Base;
using Titan.Blog.IAppService;
using Titan.Blog.IAppService.Base;
using Titan.Blog.IRepository;
using Titan.Blog.Model.DataModel;

namespace Titan.Blog.AppService
{
    public class ChildrenServices : BaseServices<Children,Guid>, IChildrenServices
    {
        private readonly IMainRepository _iMainRepository;
        private readonly IChildrenRepository _iChildrenRepository;

        public ChildrenServices(IMainRepository iMainRepository, IChildrenRepository iChildrenRepository)
        {
            base.BaseRepository = iChildrenRepository;//如果要用基类封装的方法必须传值
            _iMainRepository = iMainRepository;
            _iChildrenRepository = iChildrenRepository;
        }

        public async Task AddModel(Children model)
        {
            await Add(model);
            //await Add()
            //await _iMainRepository.Add(model);
        }

        public async Task<Tuple<List<Children>,int>> GetList()
        {
            System.Linq.Expressions.Expression<Func<Children, bool>> where1 = x => x.Main.Telphone.Contains("11");
            System.Linq.Expressions.Expression<Func<Children, string>> orderby1 = x => x.Name;
            var dt = await _iChildrenRepository.Query<string>(where1, orderby1, true, 1, 10);

            System.Linq.Expressions.Expression<Func<Main, bool>> where = x => x.Telphone.Contains("11");
            System.Linq.Expressions.Expression<Func<Main, string>> orderby = x => x.Name;
            var data=await _iMainRepository.Query<string>(where, orderby, true, 1, 10);
            return dt;
        }
    }
}
