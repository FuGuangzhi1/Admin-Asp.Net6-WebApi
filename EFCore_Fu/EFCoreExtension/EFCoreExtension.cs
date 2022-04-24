using Common_Fu;
using EFCore_Fu.EFCoreExtension.ReflectEntityGetSql;
using EFCore_Fu.EFCoreFactroy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Fu.EFCoreExtension
{
    public static class EFCoreExtension
    {
       readonly static ReflectEntityGetSql.ReflectEntityGetSql reflectEntityGetSql = new ();
        public static void BatchDelete<T>
            (this DbSet<T> db, Expression<Func<T, bool>> deleteWhere) where T : class
        {
            var expressionAnalysis = new ExpressionAnalysis.ExpressionAnalysis();
            expressionAnalysis.Visit(deleteWhere);
            var sqlWhere = expressionAnalysis.GetWhereString;
            var sql = reflectEntityGetSql.GetDeleteSql<T>();
            sql += sqlWhere;
            ICurrentDbContext iCurrentDbContext = db.GetService<ICurrentDbContext>();
            iCurrentDbContext.Context.Database.ExecuteSqlRawAsync(sql);
        }
        public static void BatchUpdate()
        {


        }
    }
}
