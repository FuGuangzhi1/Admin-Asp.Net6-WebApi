using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Abstract_Fu
{
    public interface IBaseServices: IDisposable
    {
        TEntity? Add<TEntity>(TEntity entity) where TEntity : class;
        Task<TEntity?> AddAsync<TEntity>(TEntity entity, bool isSaveChanges = false) where TEntity : class;
        void AddRange<TEntity>(IEnumerable<TEntity> entites) where TEntity : class;
        Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entites) where TEntity : class;
        int? Commit();
        Task<int?> CommitAsync();
        TEntity? Find<TEntity, Tkey>(Tkey tkey) where TEntity : class;
        Task<TEntity?> FindAsync<TEntity, Tkey>(Tkey tkey) where TEntity : class;
        IQueryable<TEntity> GetIQueryTable<TEntity>() where TEntity : class;
        IQueryable<TEntity>? Query<TEntity>(Expression<Func<TEntity, bool>> funWhere) where TEntity : class;
        IQueryable<TEntity>? QueryEntityCommon<TEntity>(Expression<Func<TEntity, bool>> funWhere) where TEntity : class;
        TEntity? Remove<TEntity>(TEntity entity) where TEntity : class;
        Task<TEntity?> RemoveAsync<TEntity, Tkey>(Tkey id, bool isSaveChanges = false) where TEntity : class;
        Task<TEntity?> RemoveSoftAsync<TEntity, Tkey>(Tkey id, bool isSaveChanges = false) where TEntity : class;
        void RemoveAsync<TEntity>(IEnumerable<TEntity> entites) where TEntity : class;
        Task<TEntity?> RemoveAsync<TEntity>(TEntity entity, bool isSaveChanges = false) where TEntity : class;
        Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entites) where TEntity : class;
        TEntity? Update<TEntity>(TEntity entity) where TEntity : class;
        Task<TEntity?> UpdateAsync<TEntity>(TEntity entity, bool isSaveChanges = false) where TEntity : class;
        void UpdateRange<TEntity>(IEnumerable<TEntity> entites) where TEntity : class;
        Task UpdateRangeAsync<TEntity>(IEnumerable<TEntity> entites) where TEntity : class;
    }
}