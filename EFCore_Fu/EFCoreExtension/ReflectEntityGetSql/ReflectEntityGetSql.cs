using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Fu.EFCoreExtension.ReflectEntityGetSql
{
    public class ReflectEntityGetSql
    {
        public string GetDeleteSql<T>()
        {
            var type = typeof(T);
            string tableName = type.Name;
            type.GetCustomAttributes(true).ToList().ForEach(t =>
            {
                if (t is TableAttribute attribute)
                {
                    tableName = attribute.Name;
                }
            });
            string sql = $"delete from {tableName}  where ";
            return sql;
        }
    }
}
