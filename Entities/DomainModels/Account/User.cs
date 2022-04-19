global using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entites.DomainModels.Account;

[Table("User")]
public class User : BaseModel
{
    [MaxLength(length: 12)]
    public string? Name { get; set; } = null;
    [MaxLength(length: 50)]
    [EmailAddress]
    public string? Email { get; set; } = null;
    [MaxLength(length: 50)]
    public string? Account { get; set; } = null;
    [MaxLength(length: 6)]
    public string? Sex { get; set; } = null;
    public int Age { get; set; } = 0;

}

