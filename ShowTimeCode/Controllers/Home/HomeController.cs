using Abstract_Fu.Home;
using Entities.DtoModels.MenuDto;
using System.Collections.Generic;

namespace ShowTimeCode.Controllers.Home;

public class HomeController : ApiClass
{
    private readonly IHomeInterface _interface;

    public HomeController(IHomeInterface services)
    {
        this._interface = services;
    }
    [HttpGet("GetMenu"), HttpPost("GetMenu")]
    public async Task<ApiFormat> GetMenuAync()
    {
        Guid? identity = base.User.Identity?.Name.ToGuid();
        if (identity == null)
            return base.Error(massage: "身份过期或者恶意操作，数据获取失败");

        IEnumerable<MenuDto>? menuData = await _interface.FindIdbyMenuDataAsync(identity);
        return base.SussucNoTip(data: menuData);
    }
}

