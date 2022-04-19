using Common_Fu.ExeclHelper;

namespace Entites.DomainModels.BaseModels;

/// <summary>
/// 领域实体
/// </summary>
public class BaseModel : IEntityCommon, ISoftDelete
{
    public Guid Id { get; set; }
    [Title(Title = "创建时间")]
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? CreateTime { get; set; }
    [Title(Title = "修改时间")]
    public DateTime UpdateTime { get; set; }
    public bool IsDeleted { get; set; }
}
/// <summary>
/// 必备字段
/// </summary>
public interface IEntityCommon
{
    public DateTime? CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
/// <summary>
/// 带软删除的领域实体
/// </summary>
public interface ISoftDelete
{
    public bool IsDeleted { get; set; }
}