using Common_Fu.ExeclHelper;

namespace Entities.DomainModels.Study;

[Table("StudyInfo")]
public class StudyInfo : BaseModel
{
    [Title(Title = "知识名称")]
    public string? StudyInfoName { get; set; } = null;
    [Title(Title = "知识描述")]
    public string? StudyInfoDescribe { get; set; } = null;
    public Guid? StudyTypeId { get; set; }
}

