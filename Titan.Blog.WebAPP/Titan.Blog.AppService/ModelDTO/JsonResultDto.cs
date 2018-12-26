using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Titan.AppService.ModelDTO
{
    #region APP接口统一返回json
    public class JsonResultDto
    {
        public JsonResultDto()
        {
            StatusCode = "8000";
            StatusMsg = "成功";
        }
        //状态编码
        public string StatusCode { get; set; }
        //状态信息
        public string StatusMsg { get; set; }
        /// <summary>
        /// 分页信息
        /// </summary>
        public PageInfo PageInfo { get; set; }

        /// <summary>
        /// 版本号
        /// </summary>
        public double Version { get; set; }

        //返回数据
        public object Data { get; set; }
    }
    #endregion

    #region 分页
    /// <summary>
    /// 分页信息
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecords { get; set; }

        /// <summary>
        /// 请求Url
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 参数
        /// </summary>
        public PagePara PageParas { get; set; }
    }

    /// <summary>
    /// 参数
    /// </summary>
    public class PagePara
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public JsonPara Self { get; set; }

        /// <summary>
        /// 首页
        /// </summary>
        public JsonPara First { get; set; }

        /// <summary>
        /// 末页
        /// </summary>
        public JsonPara Last { get; set; }

        /// <summary>
        /// 前一页
        /// </summary>
        public JsonPara Privious { get; set; }

        /// <summary>
        /// 后一页
        /// </summary>
        public JsonPara Next { get; set; }
    }
    #endregion

    #region APP统一接口请求参数
    /// <summary>
    /// Json参数
    /// </summary>
    public class JsonPara
    {
        //凭证
        public string Token { get; set; }
        //服务类型
        public string ServiceType { get; set; }
        //方法名
        public string Method { get; set; }

        /// <summary>
        /// 页码对于返回IEnumerable类型的方法添加Paged特性来使用通用分页
        /// </summary>
        public int? PageNumber { get; set; } = null;

        /// <summary>
        /// 版本号
        /// </summary>
        public double Version { get; set; } = 0;

        //方法参数
        public MethodParameter[] Paras { get; set; }
    }
    /// <summary>
    /// 参数键值对
    /// </summary>
    public class MethodParameter
    {
        public string ParaName { get; set; }
        public object ParaValue { get; set; }
    }
    #endregion
}
