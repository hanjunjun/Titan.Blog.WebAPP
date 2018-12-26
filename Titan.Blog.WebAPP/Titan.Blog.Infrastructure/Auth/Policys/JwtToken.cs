using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Titan.Blog.Infrastructure.Data;

namespace Titan.Blog.Infrastructure.Auth.Policys
{
    /// <summary>
    /// JWTToken生成类
    /// </summary>
    public class JwtToken
    {
        /// <summary>
        /// 获取基于JWT的Token
        /// </summary>
        /// <param name="claims">需要在登陆的时候配置</param>
        /// <param name="permissionRequirement">在startup中定义的参数</param>
        /// <returns></returns>
        public static OpResult<object> BuildJwtToken(Claim[] claims, PermissionRequirement permissionRequirement)
        {
            try
            {
                var now = DateTime.Now;
                // 实例化JwtSecurityToken
                var jwt = new JwtSecurityToken(
                    issuer: permissionRequirement.Issuer,
                    audience: permissionRequirement.Audience,
                    claims: claims,
                    notBefore: now,
                    expires: now.Add(permissionRequirement.Expiration),
                    signingCredentials: permissionRequirement.SigningCredentials
                );
                // 生成 Token
                var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
                //打包返回前台
                var json = new
                {
                    success = true,
                    token = encodedJwt,
                    expires_in = permissionRequirement.Expiration.TotalSeconds,
                    token_type = "Bearer"
                };
                return new OpResult<object>(OpResultType.Success, "",json);
            }
            catch (Exception e)
            {
                return new OpResult<object>(OpResultType.AuthInvalid,$"令牌生成错误：{e.Message}");
            }
        }
    }
}
