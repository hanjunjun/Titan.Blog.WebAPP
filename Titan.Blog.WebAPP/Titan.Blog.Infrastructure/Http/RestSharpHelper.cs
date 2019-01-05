/************************************************************************
 * 文件名：RestSharpHelper
 * 文件功能描述：xx控制层
 * 作    者：  韩俊俊
 * 创建日期：2019/1/4 10:56:51
 * 修 改 人：
 * 修改日期：
 * 修改原因：
 * Copyright (c) 2017 . All Rights Reserved. 
 * ***********************************************************************/
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Titan.Blog.Infrastructure.Http
{
    public class RestSharpHelper
    {
        public static string HttpGet(string url, int timeOut = 30*1000)
        {
            IRestClient client = new RestClient(url);
            IRestRequest request = new RestRequest(Method.GET);
            request.Timeout = timeOut;
            IRestResponse restResponse = client.Execute(request);
            return restResponse.Content;
        }
    }
}
