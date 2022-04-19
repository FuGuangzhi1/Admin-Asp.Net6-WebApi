
namespace Entites.DomainModels.Role;
/// <summary>
/// 角色表
/// </summary>
[Table("Roles")]
public class Role : BaseModel
{
    [Required]
    public string RoleName { get; set; } = null!;
    public string RoleDescribe { get; set; } = null!;
}
