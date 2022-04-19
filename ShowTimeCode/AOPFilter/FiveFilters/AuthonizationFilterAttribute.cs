using Microsoft.AspNetCore.Mvc.Filters;

namespace ShowTimeCode.AOPFilter.FiveFilters;

/// <summary>
/// 通过 Authonization Filter 可以实现复杂的权限角色认证、登陆授权等操作
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class CustomAuthonizationFilterAttribute : Attribute, IAuthorizationFilter
{

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string token = context.HttpContext.Request.Headers["Authorization"];
    }



}

