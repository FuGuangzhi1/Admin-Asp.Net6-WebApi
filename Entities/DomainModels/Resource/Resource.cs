global using System.ComponentModel.DataAnnotations;

namespace Entites.DomainModels.Resource;

/// <summary>
/// 资源表
/// </summary>
[Table("Resource")]
public class Resource : BaseModel
{
    [Required]
    public string ResourceName { get; set; } = null!;
    public Nullable<Guid> ParentId { get; set; } = default!;
    public string Path { get; set; } = null!;
    public long Level { get; set; } = 0;   //层级
    public string Icon { get; set; } = null!;
    public int Sort { get; set; } = 0;
}