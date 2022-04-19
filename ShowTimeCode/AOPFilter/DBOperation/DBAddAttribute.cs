using Abstract_Fu;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace ShowTimeCode.AOPFilter.DBOperation
{
    public class DBAddAttribute: ActionFilterAttribute
    {
        private readonly string _entityName;

        public DBAddAttribute(string entityName)
        {
            this._entityName = entityName;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool isAnyParameter = context.ActionArguments.TryGetValue(_entityName, out object? entity);
            if (isAnyParameter)
            {
                entity?.InitDomainEntity(true);
                context.ActionArguments[_entityName] = entity;
            }
            base.OnActionExecuting(context);
        }
    }
}
