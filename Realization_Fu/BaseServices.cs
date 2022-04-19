using Abstract_Fu;
using Common_Fu;
using EFCore_Fu;
using EFCore_Fu.EFCoreFactroy;
using Entites.DomainModels.BaseModels;
using Microsoft.EntityFrameworkCore;
using ServiceStack;
using System.Collections;
using System.Linq.Expressions;

namespace Realization_Fu
{
    public abstract class BaseServices : IBaseServices
    {
        //private readonly IEFCoreFactory _iEFCoreFactory;
        private readonly MyDBContext? _dBContext = null;

        public BaseServices(IEFCoreFactory EFCoreFactory)
        {
            //this._iEFCoreFactory = EFCoreFactory;
            this._dBContext = EFCoreFactory.CreateDefaultDBContext();
        }
        public IQueryable<TEntity> GetIQueryTable<TEntity>() where TEntity : class
        {
            return this._dBContext!.Set<TEntity>().AsQueryable();
        }

        #region AddAll
        /// <summary>
        /// 添加
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public TEntity? Add<TEntity>(TEntity entity) where TEntity : class
          => this._dBContext?
            .Add(entity)?
            .Entity;
        //添加 异步
        public async Task<TEntity?> AddAsync<TEntity>(TEntity entity, bool isSaveChanges = false) where TEntity : class
        {
            await this._dBContext!.AddAsync(entity);
            if (isSaveChanges) await CommitAsync();
            return entity;
        }
        public void AddRange<TEntity>
            (IEnumerable<TEntity> entites)
          where TEntity : class
        => this._dBContext!.AddRange(entites);
        /// <summary>
        /// 批量添加 异步
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entites"></param>
        /// <returns></returns>
        public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entites)
            where TEntity : class
          => await this._dBContext!.AddRangeAsync(entites);

        #endregion

        #region RemoveAll
        public TEntity? Remove<TEntity>
            (TEntity entity)
            where TEntity : class
          => this._dBContext?
            .Remove(entity)?
            .Entity;
        public async Task<TEntity?> RemoveAsync<TEntity, Tkey>
          (Tkey id, bool isSaveChanges = false)
            where TEntity : class
        {
            var entity = await this._dBContext
              !.FindAsync<TEntity>(id);
            if (entity is not null)
            {
                this._dBContext?
                      .Remove<TEntity>(entity);
                if (isSaveChanges) await this._dBContext!.SaveChangesAsync();
                return entity;
            }

            else return null;
        }
        public async Task<TEntity?> RemoveSoftAsync<TEntity, Tkey>
        (Tkey id, bool isSaveChanges = false)
          where TEntity : class
        {
            var entity = await this._dBContext
              !.FindAsync<TEntity>(id);
            if (entity is not null)
            {
                entity.SoftDeleteDomainEntity();
                this._dBContext?
                      .Update<TEntity>(entity);
                if (isSaveChanges) await this._dBContext!.SaveChangesAsync();
                return entity;
            }

            else return null;
        }
        public async Task<TEntity?> RemoveAsync<TEntity>(TEntity entity, bool isSaveChanges = false) where TEntity : class
        {
            this._dBContext?.Remove<TEntity>(entity);
            if (isSaveChanges) await this._dBContext!.SaveChangesAsync();
            return entity;
        }

        public void RemoveAsync<TEntity>
          (IEnumerable<TEntity> entites)
           where TEntity : class
           => this._dBContext!.RemoveRange(entites);
        /// <summary>
        /// 批量删除 异步
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entites"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync<TEntity>(IEnumerable<TEntity> entites)
            where TEntity : class
           => await Task.Run(() => this._dBContext
               !.RemoveRange(entites));

        #endregion

        #region UpdateAll
        public TEntity? Update<TEntity>(TEntity entity) where TEntity : class
          => this._dBContext
            ?.Update(entity)
            ?.Entity;
        public async Task<TEntity?> UpdateAsync<TEntity>(TEntity entity, bool isSaveChanges = false) where TEntity : class
        {
            this._dBContext
                ?.Update(entity);
            if (isSaveChanges) await this._dBContext!.SaveChangesAsync();
            return entity;
        }
        public void UpdateRange<TEntity>
            (IEnumerable<TEntity> entites)
            where TEntity : class
           => this._dBContext
               ?.UpdateRange(entites);

        public async Task UpdateRangeAsync<TEntity>
           (IEnumerable<TEntity> entites)
           where TEntity : class
          => await Task
            .Run(() =>
             this._dBContext?.UpdateRange(entites));
        #endregion

        #region Query 

        public IQueryable<TEntity>? Query<TEntity>
    (Expression<Func<TEntity, bool>> funWhere) where TEntity : class
         => this._dBContext
          ?.Set<TEntity>()
          ?.Where(funWhere);
        public IQueryable<TEntity>? QueryEntityCommon<TEntity>
        (Expression<Func<TEntity, bool>> funWhere) where TEntity : class
             => this._dBContext
                ?.Set<TEntity>()
                ?.Where(funWhere);
        public TEntity? Find<TEntity, Tkey>
            (Tkey tkey) where TEntity : class
        => this._dBContext
        ?.Find<TEntity>(tkey);
        public async Task<TEntity?> FindAsync<TEntity, Tkey>
       (Tkey tkey) where TEntity : class
       => await this._dBContext
         !.FindAsync<TEntity>(tkey);

        #endregion

        #region  commitAll
        public int? Commit()
          => this._dBContext?
            .SaveChanges();
        public async Task<int?> CommitAsync()
          => await this._dBContext!
            .SaveChangesAsync();
        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _dBContext?.DisposeAsync().AsTask().Wait();
        }

    }
}