
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShowTimeCode.AOPFilter.FiveFilters;

/// <summary>
/// 结果过滤器，可以对结果进行格式化、大小写转换等一系列操作。
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class CustomResultFilterAttribute : Attribute, IResultFilter
{
    public void OnResultExecuted(ResultExecutedContext context)
    {

    }


    public void OnResultExecuting(ResultExecutingContext context)
    {

    }
}

