﻿using Abstract_Fu.Account;
using Abstract_Fu.Home;
using Abstract_Fu.PersonalManagement.PersonalInfo;
using Abstract_Fu.PersonalManagement.StudyInfo;
using Autofac;
using Common_Fu.ExeclHelper;
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
            ////把服务的注入规则写在这里
            //builder.RegisterType<EFCoreFactory>().As<IEFCoreFactory>();
            //builder.RegisterType<MyNpoiExeclHelper>().As<IMyNpoiExeclHelper>();
            //builder.RegisterType<DBSaveChangesAttribute>();
        }
    }
}
