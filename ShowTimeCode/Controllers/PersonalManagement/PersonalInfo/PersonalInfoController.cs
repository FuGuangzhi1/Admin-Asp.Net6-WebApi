using Abstract_Fu.PersonalManagement.PersonalInfo;
using Common_Fu;
using Entites.DomainModels.Account;
using Microsoft.AspNetCore.Authorization;

namespace ShowTimeCode.Controllers.PersonalManagement.PersonalInfo;
[AllowAnonymous]
public class PersonalInfoController : ApiClass
{
    public record struct Data
    {
        public string? ImgSrc { get; set; }
        public string? ImgName { get; set; }
    }
    private readonly IPersonalInfoInterface _interface;

    public PersonalInfoController(IPersonalInfoInterface services)
    {
        this._interface = services;
    }
    [HttpGet("GetUser")]
    public async Task<ApiFormat> GetUserAsync()
    {
        Guid? identity = base.User.Identity?.Name.ToGuid();
        User? claims = await this._interface.GetUserAsync(identity);
        return base.SussucNoTip(data: claims);
    }
    [HttpPost("SaveImg")]
    public async Task<ApiFormat> SaveImgAsync(IFormFile formFile)
    {
        Guid? identity = base.User.Identity?.Name.ToGuid();
        Stream imgFile = formFile.OpenReadStream();

        string data = imgFile.FileToBase64();
        bool? isAdd = await this._interface
            .SaveProfilePhotoImgAsync(identity, formFile.FileName, data);
        if (isAdd is true)
        {
            return base.Sussuc(massage: "头像上传成功");
        }
        else
        {
            return base.Sussuc(massage: "头像修改成功");
        }
    }
    [HttpPost("SaveImgBase64")]
    public async Task<ApiFormat> SaveImgBase64Async(Data data)
    {
        Guid? identity = base.User.Identity?.Name.ToGuid();
        if (data.ImgSrc is null)
            return base.Error(massage: "上传数据为空");
        bool? isAdd = await this._interface
            .SaveProfilePhotoImgAsync(identity, data.ImgName ?? "", data.ImgSrc);
        if (isAdd is true)
        {
            return base.Sussuc(massage: "头像上传成功");
        }
        else
        {
            return base.Sussuc(massage: "头像修改成功");
        }
    }
    [HttpGet("GetProfilePhoto")]
    public async Task<ApiFormat> GetProfilePhotoAsync()
    {
        Guid? identity = base.User.Identity?.Name.ToGuid();
        string? ProfilePhotoData = await this._interface.GetProfilePhotoAsync(identity);
        return base.SussucNoTip(data: ProfilePhotoData);
    }
}

