using Abstract_Fu.Account;
using Entites.DomainModels.Account;
using Entites.ViewModel.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using ShowTimeCode.Controllers.ApiHelper;
using ShowTimeCode.JWTHelper;

namespace ShowTimeCode.Controllers.Account;
[AllowAnonymous]
public class AccountController : ApiClass
{
    private readonly IAccountInterface _interface;
    private readonly JWTTokenOptions _tokenOptions;

    public AccountController
        (IAccountInterface services, JWTTokenOptions tokenOptions)
        => (this._interface, this._tokenOptions) = (services, tokenOptions);
    [HttpPost("Login")]
    public async Task<ApiFormat> LoginAsync
   (LoginData loginData)
    {
        var identity = await this._interface.Login(loginData);
        var result = identity.Item2 switch
        {
            true => base.Sussuc(massage: "登录成功"),
            false => base.Error(massage: "账号密码错误,登录失败")
        };
        var id = identity.Item1?.Id;
        if (id is not null)
        {
            var token = new JwtTokenHelper().AuthorizeToken(id, _tokenOptions);
            result.Data = token;
        }
        return result;
    }

}



