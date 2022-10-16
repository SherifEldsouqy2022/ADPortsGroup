using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using ADPortsGroup.Configuration;

namespace ADPortsGroup.Web.Host.Startup
{
    [DependsOn(
       typeof(ADPortsGroupWebCoreModule))]
    public class ADPortsGroupWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public ADPortsGroupWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(ADPortsGroupWebHostModule).GetAssembly());
        }
    }
}
