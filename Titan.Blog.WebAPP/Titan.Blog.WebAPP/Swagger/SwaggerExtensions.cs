using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Titan.Blog.WebAPP.Swagger
{
    public class SwaggerExtensions
    {
        public const string HTML = @"<!DOCTYPE html>
<html>
    <head>
        <title>tool</title>
        <style type='text/css'>
            .bg {
            background-color: rgb(84, 127, 177);
            }

            tr {
            height: 20px;
            font-size: 12px;
            }

            .specialHeight {
            height: 40px;
            }
        </style>
    </head>
    <body>
        <div style='width:800px; margin: 0 auto'>
                <h4>授权模块</h4>
                <h7>Authorization</h5>
                <table border='1' cellspacing='0' cellpadding='0' width='100%'>
                    <tr class='bg'>
                        <td colspan='5'><c:out value='${t.tag}'/></td>
                    </tr>
                    <tr>
                        <td>接口描述</td>
                        <td colspan='4'>获取token授权密钥</td>
                    </tr>
                    <tr>
                        <td>URL</td>
                        <td colspan='4'>/api/v2/Authorization/LoginV2</td>
                    </tr>
                    <tr>
                        <td>请求方式</td>
                        <td colspan='4'>get</td>
                    </tr>
                    <tr>
                        <td>请求类型</td>
                        <td colspan='4'>multipart/form-data</td>
                    </tr>
                    <tr>
                        <td>返回类型</td>
                        <td colspan='4'>${t.responseForm}</td>
                    </tr>

                    <tr class='bg' align='center'>
                        <td>参数名</td>
                        <td>数据类型</td>
                        <td>参数类型</td>
                        <td>是否必填</td>
                        <td>说明</td>
                    </tr>
                    <c:forEach items='${t.requestList}' var='req'>
                        <tr align='center'>
                            <td>name</td>
                            <td>string</td>
                            <td>query</td>
                            <td>
                                <c:choose>
                                    <c:otherwise>N</c:otherwise>
                                </c:choose>
                            </td>
                            <td>账号</td>
                        </tr>
                    </c:forEach>
                    <tr class='bg' align='center'>
                        <td>状态码</td>
                        <td>描述</td>
                        <td colspan='3'>说明</td>
                    </tr>

                    <c:forEach items='${t.responseList}' var='res'>
                        <tr align='center'>
                            <td>201</td>
                            <td>成功</td>
                            <td colspan='3'>成功提示</td>
                        </tr>
                    </c:forEach>

                    <tr class='bg'>
                        <td colspan='5'>示例</td>
                    </tr>
                    <tr class='specialHeight'>
                        <td class='bg'>请求参数</td>
                        <td colspan='4'>userid=1&password=1</td>
                    </tr>
                    <tr class='specialHeight'>
                        <td class='bg'>返回值</td>
                        <td colspan='4'>token</td>
                    </tr>
                </table>
                <br>
				<h4>博客模块</h4>
                <h7>Authorization</h5>
                <table border='1' cellspacing='0' cellpadding='0' width='100%'>
                    <tr class='bg'>
                        <td colspan='5'><c:out value='${t.tag}'/></td>
                    </tr>
                    <tr>
                        <td>接口描述</td>
                        <td colspan='4'>获取token授权密钥</td>
                    </tr>
                    <tr>
                        <td>URL</td>
                        <td colspan='4'>/api/v2/Authorization/LoginV2</td>
                    </tr>
                    <tr>
                        <td>请求方式</td>
                        <td colspan='4'>get</td>
                    </tr>
                    <tr>
                        <td>请求类型</td>
                        <td colspan='4'>multipart/form-data</td>
                    </tr>
                    <tr>
                        <td>返回类型</td>
                        <td colspan='4'>${t.responseForm}</td>
                    </tr>

                    <tr class='bg' align='center'>
                        <td>参数名</td>
                        <td>数据类型</td>
                        <td>参数类型</td>
                        <td>是否必填</td>
                        <td>说明</td>
                    </tr>
                    <c:forEach items='${t.requestList}' var='req'>
                        <tr align='center'>
                            <td>name</td>
                            <td>string</td>
                            <td>query</td>
                            <td>
                                <c:choose>
                                    <c:otherwise>N</c:otherwise>
                                </c:choose>
                            </td>
                            <td>账号</td>
                        </tr>
                    </c:forEach>
                    <tr class='bg' align='center'>
                        <td>状态码</td>
                        <td>描述</td>
                        <td colspan='3'>说明</td>
                    </tr>

                    <c:forEach items='${t.responseList}' var='res'>
                        <tr align='center'>
                            <td>201</td>
                            <td>成功</td>
                            <td colspan='3'>成功提示</td>
                        </tr>
                    </c:forEach>

                    <tr class='bg'>
                        <td colspan='5'>示例</td>
                    </tr>
                    <tr class='specialHeight'>
                        <td class='bg'>请求参数</td>
                        <td colspan='4'>userid=1&password=1</td>
                    </tr>
                    <tr class='specialHeight'>
                        <td class='bg'>返回值</td>
                        <td colspan='4'>token</td>
                    </tr>
                </table>
                <br>
        </div>
    </body>
</html>
";
    }
}
