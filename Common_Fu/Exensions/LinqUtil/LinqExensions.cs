using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace System.Linq
{
    public static class LinqExensions
    {
        public static IQueryable<TSource> WhereIf<TSource>
            (this IQueryable<TSource> source, bool isNull,
            Expression<Func<TSource, bool>> predicate) where TSource : class
           => isNull ? source : source.Where(predicate);
        public static IQueryable<TSource> ToPage<TSource,S>
            (this IQueryable<TSource> source,
            Expression<Func<TSource, S>> funWhere,
            bool isDesc = true,
            int currentPage = 1, int pageSize = 10)
        {
            if (pageSize == 0) pageSize = 10;
            if (currentPage == 0) currentPage = 1;
            int offset = (currentPage - 1) * pageSize;
            if (isDesc)
            {
                source = source.OrderBy(funWhere);
            }
            else 
            { 
                source = source.OrderByDescending(funWhere); 
            }
            source = source.Skip(offset).Take(pageSize);
            return source;
        }

    }
}
