global using ShowTimeCode.Controllers.ApiHelper;
using EFCore_Fu.EFCoreExtension;
using EFCore_Fu.EFCoreFactroy;
using Entites.DomainModels.Account;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace ShowTimeCode.Controllers.Test
{
    public class TestController : ApiClass
    {
        private readonly IEFCoreFactory _iEFCoreFactory;

        public TestController(IEFCoreFactory iEFCoreFactory)
        {
            this._iEFCoreFactory = iEFCoreFactory;
        }

        [HttpGet(nameof(TestIdentity))]
        public ApiFormat TestIdentity()
          => base.Sussuc(massage: "测试成功");

        [HttpGet(nameof(TestIIS)), AllowAnonymous]
        public ApiFormat TestIIS()
          => base.Sussuc(massage: "测试成功");

        [HttpGet(nameof(TestObject)), AllowAnonymous]
        public ApiFormat TestObject()
        {
            var user = new User();
            user.InitDomainEntity();
            return base.Sussuc(massage: "测试成功");
        }
        [HttpGet(nameof(TestBatch)), AllowAnonymous]
        public async Task<ApiFormat> TestBatch()
        {
            await using var dbContext = this._iEFCoreFactory.CreateDefaultDBContext();
            dbContext.TestTable.BatchDelete(x => x.TsetInt > 12121212 
            && x.TsetDateTime >DateTime.Now
            && x.IsDeleted
            && x.TsetString=="aa");
            dbContext.SaveChanges();
            return base.Sussuc(massage: "测试成功");
        }
    }

}
