global using ShowTimeCode.Controllers.ApiHelper;
using Entites.DomainModels.Account;
using Microsoft.AspNetCore.Authorization;

namespace ShowTimeCode.Controllers.Test
{
    public class TestController : ApiClass
    {
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
    }

}
