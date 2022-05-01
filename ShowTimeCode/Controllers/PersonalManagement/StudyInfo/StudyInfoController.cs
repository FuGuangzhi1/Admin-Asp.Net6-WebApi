using Abstract_Fu.PersonalManagement.StudyInfo;
using Microsoft.AspNetCore.Authorization;
namespace ShowTimeCode.Controllers.PersonalManagement.StudyInfo;

using Common_Fu.ExeclHelper;
using Common_Fu.ExeclHelper.Exensions;
using Entities.DomainModels.Study;
using Entities.ViewModels.Select;
using Entities.ViewModels.Study;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using ShowTimeCode.AOPFilter.DBOperation;
using ShowTimeCode.AOPFilter.FiveFilters;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

public class StudyInfoController : ApiClass
{
    private readonly IStudyInfoInterface _interface;
    private readonly IMyNpoiExeclHelper _myNpoiExeclHelper;

    public StudyInfoController(IStudyInfoInterface services, IMyNpoiExeclHelper myNpoiExeclHelper)
    {
        this._interface = services;
        this._myNpoiExeclHelper = myNpoiExeclHelper;
    }

    [HttpGet("GetStudyInfoView")]
    //[ResponseCache(Duration = 3600)]
    // [TypeFilter(typeof(CustomResourceFilterAttribute))]

    public async Task<ApiFormat> GetStudyInfoViewAsync(string? studyInfoName, Guid? studyTypeId, int currentPage, int pageSize)
       => base.Sussuc(massage: "表格数据加载成功", data: await this._interface.GetIQueryTable<StudyInfo>().AsNoTracking()
               .Join(this._interface.GetIQueryTable<StudyType>()
               , t1 => t1.StudyTypeId,
               t2 => t2.Id, (t1, t2) => new StudyInfoView
               {
                   CreateTime = t1.CreateTime,
                   Id = t1.Id,
                   IsDeleted = t1.IsDeleted,
                   StudyInfoDescribe = t1.StudyInfoDescribe,
                   StudyInfoName = t1.StudyInfoName,
                   StudyTypeDescribe = t2.StudyTypeDescribe,
                   StudyTypeId = t1.StudyTypeId,
                   StudyTypeName = t2.StudyTypeName,
                   UpdateTime = t1.UpdateTime,
               })
               .WhereIf(studyInfoName is null or "", x => x.StudyInfoName == studyInfoName)
               .WhereIf(studyTypeId is null, x => x.StudyTypeId == studyTypeId)
               .ToPage(x => x.CreateTime, true, currentPage, pageSize).AsQueryable()
               .ToListAsync(),
               tatol: await this._interface
                .GetIQueryTable<StudyInfo>().AsNoTracking()
                .WhereIf(studyInfoName is null or "", x => x.StudyInfoName == studyInfoName)
                .WhereIf(studyTypeId is null, x => x.StudyTypeId == studyTypeId)
                .CountAsync());

    [HttpPost("AddStudyInfo"), DBAdd("studyInfo")]
    public async Task<ApiFormat> AddStudyInfoAsync(StudyInfo? studyInfo) =>
        base.Sussuc(massage: "添加数据成功",
            data: await this._interface
            .AddAsync<StudyInfo>(studyInfo ?? throw new Exception("添加空数据无效"), true));
    [HttpPut("EditStudyInfo")]
    public async Task<ApiFormat> EditStudyInfoAsync(StudyInfo? studyInfo) =>
        base.Sussuc(massage: "修改数据成功",
            data: await this._interface
            .UpdateAsync<StudyInfo>(studyInfo ?? throw new Exception("修改空数据无效"), true));
    [HttpDelete("RemoveStudyInfo")]
    public async Task<ApiFormat> RemoveStudyInfoAsync(Guid id) =>
        base.Sussuc(massage: "删除数据成功",
            data: await this._interface.RemoveSoftAsync<StudyInfo, Guid>(id, true));
    [HttpGet("GetStudyType")]
    public async Task<ApiFormat> GetStudyType() =>
        base.SussucNoTip(data: await (from T1 in this._interface.GetIQueryTable<StudyType>()
                                      select new Select
                                      {
                                          Id = T1.Id.ToString(),
                                          Value = T1.StudyTypeName

                                      }).ToListAsync());
    [HttpGet("GetStudyInfoExecl")]
    public async Task<IActionResult> GetStudyInfoExeclAsync(string? execlName, string? sheetName, bool? isXlsx = false)
    {
        string contentType;
        if (isXlsx is false)
        {
            contentType = "application/vnd.ms-excel";
        }
        else contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        var data = await this._interface.GetIQueryTable<StudyInfo>().AsNoTracking().ToListAsync();
        IWorkbook wookBook = this._myNpoiExeclHelper.CreateExecl<StudyInfo>(data, sheetName ?? "sheet",
            isXlsx ?? false);
        byte[] stream = wookBook.ExeclTobyte();
        return File(stream, contentType,
            execlName ?? Guid.NewGuid().ToString());
        //保存到电脑
        //await using FileStream fileStream = new($@"H:\{execlName ?? Guid.NewGuid().ToString()}.xls", FileMode.Create);
        //wookBook.Write(fileStream);
    }

}