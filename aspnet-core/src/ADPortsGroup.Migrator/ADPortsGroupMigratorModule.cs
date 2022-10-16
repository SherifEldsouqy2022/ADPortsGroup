using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ADPortsGroup.Configuration;
using ADPortsGroup.EntityFrameworkCore;
using ADPortsGroup.Migrator.DependencyInjection;

namespace ADPortsGroup.Migrator
{
    [DependsOn(typeof(ADPortsGroupEntityFrameworkModule))]
    public class ADPortsGroupMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public ADPortsGroupMigratorModule(ADPortsGroupEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(ADPortsGroupMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                ADPortsGroupConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ADPortsGroupMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
