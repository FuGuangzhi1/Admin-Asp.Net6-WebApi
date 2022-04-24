using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DomainModels
{
    [Table("TestTable")]
    public class TestTable : BaseModel
    {
        public int TsetInt { get; set; }
        public string? TsetString { get; set; }
        public DateTime? TsetDateTime { get; set; }
        public bool TsetBool { get; set; }
    }
}
