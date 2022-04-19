global using Entites.DomainModels.BaseModels;

namespace Entities.DomainModels.RelationshipTable;
/// <summary>
/// 用户角色表
/// </summary>
[Table("UserRoles")]
public class UserRole : ISoftDelete, IEntityCommon
{
    public Guid UserId { get; set; } = Guid.Empty;
    public Guid RoleId { get; set; } = Guid.Empty;
    public bool IsDeleted { get; set; }
    public DateTime? CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}
