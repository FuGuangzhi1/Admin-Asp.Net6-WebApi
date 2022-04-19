using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DomainModels.Account
{
    [Table("PassWord")]
    public class PassWord : BaseModel
    {
        [MaxLength(length: 500)]
        public string NewPassWord { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
