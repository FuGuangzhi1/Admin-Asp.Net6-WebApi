using Microsoft.AspNetCore.Mvc.Filters;

namespace ShowTimeCode.AOPFilter.FiveFilters;
public record struct Rolemanagement(string RoleName);
/// <summary>
///可以通过ActionFilter 拦截 每个执行的方法进行一系列的操作，比如：执行操作日志、参数验证，权限控制 等一系列操作。
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class CustomActionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        //if (context.ActionDescriptor.EndpointMetadata.Any(item => item is AdministratorAttribute))
        //{

        //}
    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {


    }
}

