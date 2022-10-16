using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ADPortsGroup.EntityFrameworkCore;
using ADPortsGroup.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace ADPortsGroup.Web.Tests
{
    [DependsOn(
        typeof(ADPortsGroupWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class ADPortsGroupWebTestModule : AbpModule
    {
        public ADPortsGroupWebTestModule(ADPortsGroupEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ADPortsGroupWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(ADPortsGroupWebMvcModule).Assembly);
        }
    }
}