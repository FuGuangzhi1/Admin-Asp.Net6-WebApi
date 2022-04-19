using Common_Fu;
using Common_Fu.GuidHelper;
using Entites.DomainModels.Account;
using Entites.DomainModels.Resource;
using Entites.DomainModels.Role;
using Entities.DomainModels.Account;
using Entities.DomainModels.RelationshipTable;
using Entities.DomainModels.Study;

namespace EFCore_Fu.Data.system
{
    /// <summary>
    /// 配置系统默认数据
    /// </summary>
    public static class SystemDefaultData
    {
        public static ModelBuilder AddSystemDefaultData(this ModelBuilder builder)
        {
            var id = GuidHelper.GetNewGuid();
            var user = new User
            {
                Age = 18,
                Id = id,
                Name = "小fu同学",
                Account = "1314520",
                Email = "FuGuangzhi1@Outlook.com",
                Sex = "男"
            };
            user.InitDomainEntity();

            var passWord = new PassWord
            {
                Id = GuidHelper.GetNewGuid(),
                NewPassWord = "123456".ToMD5(),
                UserId = id,
            };
            passWord.InitDomainEntity();

            var godId = GuidHelper.GetNewGuid();
            var generalId = GuidHelper.GetNewGuid();
            var poorId = GuidHelper.GetNewGuid();
            var roleList = new List<Role>
            {
               new Role
                {
                    Id = generalId,
                    RoleDescribe = "拥有一般的权限",
                    RoleName = "将臣"
                },
               new Role
               {
                   Id = poorId,
                   RoleDescribe = "小白鼠",
                   RoleName = "平民",

               },
               new Role
               {
                   Id = godId,
                   RoleDescribe = "最高权力，为所欲为",
                   RoleName = "小付同学",

               }
            };
            roleList.ForEach(role => role.InitDomainEntity());

            var personalGuid = GuidHelper.GetNewGuid();
            var systemGuid = GuidHelper.GetNewGuid();
            var personalInfomGuid = GuidHelper.GetNewGuid();
            var studyknowledgeGuid = GuidHelper.GetNewGuid();
            var journalGuid = GuidHelper.GetNewGuid();
            var userManageGuid = GuidHelper.GetNewGuid();
            var roleGuid = GuidHelper.GetNewGuid();
            var permissionsGuid = GuidHelper.GetNewGuid();
            var resourceList = new List<Resource> {
                new Resource
                {
                    Icon = "Avatar",
                    Level = 0,
                    ParentId = null,
                    Path = "",
                    Id =personalGuid,
                    ResourceName = "个人管理",
                    Sort = 0,
                },
                new Resource
                {
                    Icon = "Tools",
                    Level = 0,
                    ParentId = null,
                    Path = "",
                    Id =systemGuid,
                    ResourceName = "系统管理",
                    Sort = 1,
                },
                new Resource
                {
                    Icon = "Menu",
                    Level = 1,
                    ParentId = personalGuid,
                    Path = "PersonalInfo",
                    Id =personalInfomGuid,
                    ResourceName = "个人信息",
                    Sort = 0,
                },
                new Resource
                {
                    Icon = "Menu",
                    Level = 1,
                    ParentId =personalGuid,
                    Path = "Study",
                    Id = studyknowledgeGuid,
                    ResourceName = "学习数据",
                    Sort = 1,
                },
                new Resource
                {
                    Icon = "Menu",
                    Level = 1,
                    ParentId = personalGuid,
                    Path = "Journal",
                    Id =journalGuid,
                    ResourceName = "日志记录",
                    Sort = 2,
                },
                new Resource
                {
                    Icon = "Menu",
                    Level = 1,
                    ParentId = systemGuid,
                    Path = "UserManage",
                    Id =userManageGuid,
                    ResourceName = "用户管理",
                    Sort = 0,
                },
                new Resource
                {
                    Icon = "Menu",
                    Level = 1,
                    ParentId =systemGuid,
                    Path = "Role",
                    Id = roleGuid,
                    ResourceName = "角色管理",
                    Sort = 1,
                },
                new Resource
                {
                    Icon = "Menu",
                    Level = 1,
                    ParentId =systemGuid,
                    Path = "Permissions",
                    Id =permissionsGuid,
                    ResourceName = "权限管理",
                    Sort = 2,
                }
            };
            resourceList.ForEach(resource => resource.InitDomainEntity());

            var userRoleList = new List<UserRole>
            {
               new UserRole
            {
             UserId = id,
             RoleId = godId,
            }
            };
            var roleResourceList = new List<RoleResource>
            {
               new RoleResource
                {
                    ResourceId = personalGuid,
                    RoleId =godId,
                },
                new RoleResource
                {
                    ResourceId = systemGuid,
                    RoleId =godId,
                },
                new RoleResource
                {
                    ResourceId =personalInfomGuid,
                    RoleId =godId,
                },
                new RoleResource
                {
                    ResourceId = studyknowledgeGuid,
                    RoleId =godId,
                },
                new RoleResource
                {
                    ResourceId = journalGuid,
                    RoleId =godId,
                },
                new RoleResource
                {
                    ResourceId = userManageGuid,
                    RoleId =godId,
                },
                new RoleResource
                {

                    ResourceId = roleGuid,
                    RoleId =godId,
                },
                new RoleResource
                {
                    ResourceId = permissionsGuid,
                    RoleId =godId,
                },

                new RoleResource
                {
                    ResourceId = systemGuid,
                    RoleId = generalId,
                },
                new RoleResource
                {
                    ResourceId = personalInfomGuid,
                    RoleId = generalId,
                },
                new RoleResource
                {
                    ResourceId = studyknowledgeGuid,
                    RoleId = generalId,
                },
                new RoleResource
                {
                    ResourceId = journalGuid,
                    RoleId = generalId,
                },
                new RoleResource
                {
                    ResourceId = userManageGuid,
                    RoleId = generalId,
                },
                new RoleResource
                {

                    ResourceId = personalGuid,
                    RoleId = generalId,
                },

                new RoleResource
                {
                    ResourceId = personalGuid,
                    RoleId = poorId,
                },
                new RoleResource
                {
                    ResourceId = systemGuid,
                    RoleId = poorId,
                },
                new RoleResource
                {

                    ResourceId = personalInfomGuid,
                    RoleId = poorId,
                },
                new RoleResource
                {
                    ResourceId = studyknowledgeGuid,
                    RoleId = poorId,
                },
                new RoleResource
                {
                    ResourceId = journalGuid,
                    RoleId = poorId,
                },


            }; //不同角色对应的权限
            roleResourceList
                .ForEach(roleResource => roleResource.InitDomainEntity());

            //  var studyInfo = new StudyInfo();
            var studyTypeList = new List<StudyType>() {
            new StudyType(){
              StudyTypeName="前端",
              StudyTypeDescribe="用户看到的"
            }
            ,  new StudyType(){
              StudyTypeName="后端",
              StudyTypeDescribe="用户看不到的"
            },  new StudyType(){
              StudyTypeName="数据库",
              StudyTypeDescribe="数据操作"
            }

            };
            studyTypeList.ForEach(s => s.InitDomainEntity(true));
            #region 默认头像
            var userFile = new UserFile()
            {
                UserId = id,
                PictrueName = "默认",
                PictrueData = "无"
            };
            #endregion
            userFile.InitDomainEntity(true);
            builder.Entity<User>().HasData(user);
            builder.Entity<PassWord>().HasData(passWord);
            builder.Entity<Resource>().HasData(resourceList);
            builder.Entity<UserRole>().HasKey(x => new { x.RoleId, x.UserId });
            builder.Entity<UserRole>().HasData(userRoleList);
            builder.Entity<Role>().HasData(roleList);
            builder.Entity<RoleResource>()
                .HasKey(x => new { x.RoleId, x.ResourceId });
            builder.Entity<RoleResource>().HasData(roleResourceList);
            builder.Entity<StudyType>().HasData(studyTypeList);
            builder.Entity<UserFile>().HasData(userFile);
            return builder;
        }
    }
}
