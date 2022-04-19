

namespace Entities.DomainModels.RelationshipTable;
/// <summary>
/// 角色资源关系表
/// </summary>
[Table("RoleResource")]
public class RoleResource : ISoftDelete, IEntityCommon
{
    public Guid RoleId { get; set; } = Guid.Empty;
    public Guid ResourceId { get; set; } = Guid.Empty;
    public bool IsDeleted { get; set; }
    public DateTime? CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
