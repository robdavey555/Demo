using AutoMapper;

namespace Eintech.Repositories.Mappings
{
    public static class _MapperConfig
    {
        public static MapperConfiguration GetConfig()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new PersonProfile());
                mc.AddProfile(new GroupProfile());
            });
        }
    }
}