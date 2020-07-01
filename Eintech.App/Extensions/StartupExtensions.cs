using AutoMapper;
using Eintech.Repositories.Mappings;

namespace Eintech.App.Extensions
{
    public static class StartupExtensions
    {
        public static MapperConfiguration GetAutomapperConfig()
        {
            var mappingConfig = _MapperConfig.GetConfig();

            mappingConfig.AssertConfigurationIsValid();

            return mappingConfig;
        }
    }
}