using Entites.DomainModels.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DomainModels.Study
{
    [Table("StudyType")]
    public class StudyType : BaseModel
    {
        public string? StudyTypeName { get; set; } = null;
        public string? StudyTypeDescribe { get; set; } = null;
    }
}
