using Abstract_Fu.Account;
using Abstract_Fu.Home;
using Abstract_Fu.PersonalManagement.PersonalInfo;
using Abstract_Fu.PersonalManagement.StudyInfo;
using Autofac;
using EFCore_Fu.EFCoreFactroy;
using Realization_Fu.Account;
using Realization_Fu.Home;
using Realization_Fu.PersonalManagement.PersonalInfo;
using Realization_Fu.PersonalManagement.StudyInfo;
using ShowTimeCode.AOPFilter.DBOperation;

namespace ShowTimeCode.Utility.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //把服务的注入规则写在这里
            builder.RegisterType<EFCoreFactory>().As<IEFCoreFactory>().SingleInstance();
            builder.RegisterType<AccountServices>().As<IAccountInterface>();
            builder.RegisterType<HomeServices>().As<IHomeInterface>();
            builder.RegisterType<PersonalInfoServices>().As<IPersonalInfoInterface>();
            builder.RegisterType<StudyInfoServices>().As<IStudyInfoInterface>();
            builder.RegisterType<DBSaveChangesAttribute>();
        }
    }
}
