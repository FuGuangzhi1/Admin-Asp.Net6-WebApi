using EFCore_Fu;
using EFCore_Fu.EFCoreFactroy;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShowTimeCode.AOPFilter.DBOperation
{
    public class DBSaveChangesAttribute : ActionFilterAttribute
    {
        private readonly MyDBContext _dBContext;

        public DBSaveChangesAttribute(MyDBContext dBContext) 
        {
            this._dBContext = dBContext;
        }

        public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await this._dBContext.SaveChangesAsync();
            await base.OnResultExecutionAsync(context, next);
        }
    }
}
