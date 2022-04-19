using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShowTimeCode.JWTHelper;

public class JwtTokenHelper
{
    public JwtTokenHelper()
    {
    }

    public TokenResult? AuthorizeToken(Guid? memberId, JWTTokenOptions _tokenOptions)
    {
        if (memberId is null) return null;
        //基于声明的认证
        var claims = new[]
        {
            new Claim(ClaimTypes.Name,memberId.ToString()??""),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())//jwt的唯一标识
        };
        //秘钥 转化成UTF8编码的字节数组
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenOptions.Secret ?? ""));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);//资格证书 秘钥加密
        var jwtToken = new JwtSecurityToken(_tokenOptions.Issuer, _tokenOptions.Audience, claims,//发起人 订阅者
            expires: DateTime.Now.AddSeconds(_tokenOptions.Expire),//过期时间
            signingCredentials: credentials);//秘钥
        var securityToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);//序列化jwt格式

        //生成令牌字符串
        return new TokenResult()
        {
            Access_token = "Bearer " + securityToken,
            Expires_in = _tokenOptions.Expire
        };
    }
}




