using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ADPortsGroup.Authorization;

namespace ADPortsGroup
{
    [DependsOn(
        typeof(ADPortsGroupCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class ADPortsGroupApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<ADPortsGroupAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(ADPortsGroupApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
