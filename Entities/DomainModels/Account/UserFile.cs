using Entites.DomainModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DomainModels.Account
{
    [Table("UserFile")]
    public class UserFile : BaseModel
    {
        [MaxLength(length: 30)]
        public string? PictrueName { get; set; }
        public string? PictrueData { get; set; }
        [MaxLength(length: 200)]
        public string? GuidName { get; set; }
        public Guid? UserId { get; set; }
    }
}
