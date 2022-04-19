using Entites.DomainModels.BaseModels;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Fu.SoftDelete
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(
       this IMutableEntityType entityData)
        {
            BindingFlags bindingFlags = BindingFlags.NonPublic | BindingFlags.Static;
            var methodToCall = typeof(SoftDeleteQueryExtension)?.GetMethod(nameof(GetSoftDeleteFilter), bindingFlags)
                ?.MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall?.Invoke(null, Array.Empty<object>());
            entityData.SetQueryFilter(filter as LambdaExpression);
        }

        private static LambdaExpression GetSoftDeleteFilter<T>() where T : class, ISoftDelete
        {
            Expression<Func<T,bool> > filter = x => !x.IsDeleted;
            return filter;
        }
    }
}
