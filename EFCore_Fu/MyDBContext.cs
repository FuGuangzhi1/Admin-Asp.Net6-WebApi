global using Microsoft.EntityFrameworkCore;
using Common_Fu;
using EFCore_Fu.Data.system;
using EFCore_Fu.SoftDelete;
using Entites.DomainModels.Account;
using Entites.DomainModels.BaseModels;
using Entites.DomainModels.Resource;
using Entites.DomainModels.Role;
using Entities.DomainModels.Account;
using Entities.DomainModels.RelationshipTable;
using Entities.DomainModels.Study;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;

namespace EFCore_Fu
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; } = null!;
        public virtual DbSet<PassWord> PassWord { get; set; } = null!;
        public virtual DbSet<Resource> Resource { get; set; } = null!;
        public virtual DbSet<Role> Role { get; set; } = null!;
        public virtual DbSet<RoleResource> RoleResource { get; set; } = null!;
        public virtual DbSet<UserRole> UserRole { get; set; } = null!;
        public virtual DbSet<UserFile> UserFile { get; set; } = null!;
        public virtual DbSet<StudyInfo> StudyInfo { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddSystemDefaultData();
            //全局过滤器
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(ISoftDelete).IsAssignableFrom(entityType.ClrType))
                {
                    entityType.AddSoftDeleteQueryFilter();
                }
            }
            //区分数据库给的字段类型
            if (ConfigurationHelper.GetConfiguration.GetSection("UseSql").Value == "MYSQL")
                modelBuilder.Entity<UserFile>().Property("PictrueData").HasColumnType("longText");
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var e in base.ChangeTracker.Entries().ToList())
            {
                Func<EntityEntry, bool> AddFun = e => e.State == EntityState.Added;
                Func<EntityEntry, bool> EditFun = e => e.State == EntityState.Modified;
                if (e.Entity is BaseModel && AddFun(e))
                {
                    e.InitDomainEntity(true);
                    continue;
                }
                if (e.Entity is BaseModel && EditFun(e))
                {
                    e.EditDomainEntity();
                    continue;
                }

            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        }

    }
}