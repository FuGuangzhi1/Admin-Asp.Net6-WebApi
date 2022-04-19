using EFCore_Fu.EFCoreFactroy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShowTimeCode.Controllers.ApiHelper;

namespace ShowTimeCode.Controllers.DataBaesCreateOrDelete
{
    [AllowAnonymous]
    public class DataBaesCreateOrDeleteController : ApiClass
    {
        private readonly IEFCoreFactory _eFCoreFactory;

        public DataBaesCreateOrDeleteController(IEFCoreFactory eFCoreFactory)
        {
            this._eFCoreFactory = eFCoreFactory;
        }

        [HttpGet("CreatDataBase")]
        public async Task<ApiFormat> CreatDataBaseAsync()
        {
            await using var dBContext = this._eFCoreFactory.CreateDefaultDBContext();
            try
            {
                if (await dBContext.Database.EnsureCreatedAsync())
                {
                    return base.Sussuc(massage: "创建成功");
                }
                else
                {
                    return base.Error(massage: "创建失败");
                }
            }
            catch (Exception ex)
            {
                return base.Error(massage: ex.Message);
            }

        }
        [HttpGet("DeleteDataBase")]
        public async Task<ApiFormat> DeleteDataBaseAsync()
        {
            await using var dBContext = this._eFCoreFactory.CreateDefaultDBContext();
            try
            {
                if (await dBContext.Database.EnsureDeletedAsync())
                {
                    return base.Sussuc(massage: "删除成功");
                }
                else
                {
                    return base.Error(massage: "删除失败");
                }
            }
            catch (Exception ex)
            {
                return base.Error(massage: ex.Message);
            }


        }
    }
}
