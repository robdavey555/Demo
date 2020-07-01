using AutoMapper;
using Eintech.Data.Extensions;
using Eintech.Repositories.Mappings;

namespace Eintech.Tests
{
    public class _TestBase
    {
        protected IMapper _mapper;

        public _TestBase()
        {            
            SetUpAutoMapper();

            if(!Fakers.IsInit)
                Fakers.Init(true);
        }

        private void SetUpAutoMapper()
        {
            var mockMapper = _MapperConfig.GetConfig();
            _mapper = mockMapper.CreateMapper();
        }
    }
}