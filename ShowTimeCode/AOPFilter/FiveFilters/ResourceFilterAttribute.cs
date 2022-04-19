using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;

namespace ShowTimeCode.AOPFilter.FiveFilters;

/// <summary>
/// 资料过滤器，缓存的使用
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public class CustomResourceFilterAttribute : Attribute, IResourceFilter
{
    private readonly IMemoryCache _cache;

    public CustomResourceFilterAttribute(IMemoryCache cache)
    {
        _cache = cache;
    }

    public void OnResourceExecuted(ResourceExecutedContext context)
    {
        // 执行完后的操作
        string path = context.HttpContext.Request.Path;
        if (string.IsNullOrEmpty(path))
            return;
        string? route = context.HttpContext.Request.QueryString.Value;
        string key = path + route;
        _cache.Set(key, context.Result);
    }

    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        // 执行中的过滤器管道
        string path = context.HttpContext.Request.Path;
        if (string.IsNullOrEmpty(path))
            return;
        string? route = context.HttpContext.Request.QueryString.Value;
        string key = path + route;
        if (_cache.TryGetValue(key, out object value))
        {
            context.Result = value as IActionResult;
        }
    }
}

