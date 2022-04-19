
namespace ShowTimeCode.Controllers.ApiHelper
{
    [ApiController]
    [Route("Api/[Controller]")]
    public class ApiClass : ControllerBase
    {
        protected ApiFormat Sussuc
            (dynamic? data = null,
            string massage = "操作成功",
            int tatol = 0)
          => new()
          {
              Data = data,
              Massage = massage,
              State = 0,
              Total = tatol,
          };
        protected ApiFormat Error
           (dynamic? data = null,
           string massage = "操作失败",
           int tatol = 0)
         => new()
         {
             Data = data,
             Massage = massage,
             State = 1,
             Total = tatol,
         };
        protected ApiFormat SussucNoTip
           (dynamic? data = null,
           string massage = "",
           int tatol = 0)
           => new()
           {
               Data = data,
               Massage = massage,
               State = 4,
               Total = tatol,
           };
    }
}
