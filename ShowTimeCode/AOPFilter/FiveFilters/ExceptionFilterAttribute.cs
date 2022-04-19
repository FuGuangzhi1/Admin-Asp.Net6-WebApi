using Microsoft.AspNetCore.Mvc.Filters;

namespace ShowTimeCode.AOPFilter.FiveFilters;

/// <summary>
/// 全局错误配置
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
{
    private readonly ILogger<CustomExceptionFilterAttribute> _logger;
    //构造注入日志组件
    public CustomExceptionFilterAttribute(ILogger<CustomExceptionFilterAttribute> logger)
    {
        _logger = logger;
    }

    public void OnException(ExceptionContext context)
    {
        //日志收集
        if (!context.ExceptionHandled)
        {
            var error = context.Exception.Message;
            _logger.LogError(message: error);
            context.Result = new JsonResult(new ApiFormat
            {
                Massage = error,
                State = 1
            });
        }
    }
}

