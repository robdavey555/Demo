using AutoMapper;
using Eintech.Models;
using Eintech.Models.DTOs;
using Eintech.Repositories.Mappings;
using Xunit;

namespace Eintech.Tests
{
    public class AutomapperTests : _TestBase
    {
        private MapperConfiguration _mapperConfig;        

        public AutomapperTests()
        {
            _mapperConfig = _MapperConfig.GetConfig();            
        }

        [Fact(DisplayName = "Map_Should_HaveValidConfig")]
        public void Map_Should_HaveValidConfig()
        {
            _mapperConfig.AssertConfigurationIsValid();
        }

        [Fact(DisplayName = "Map_Should_MapPersonToPersonDTO")]
        public void Map_Should_MapPersonToPersonDTO()
        {
            var entity = new Person();
            var vm = _mapper.Map<PersonDTO>(entity);

            Assert.NotNull(vm);
            Assert.IsType<PersonDTO>(vm);
        }

        [Fact(DisplayName = "Map_Should_ReverseMapPersonToPersonDTO")]
        public void Map_Should_ReverseMapPersonToPersonDTO()
        {
            var entity = new PersonDTO();
            var vm = _mapper.Map<Person>(entity);

            Assert.NotNull(vm);
            Assert.IsType<Person>(vm);
        }

        [Fact(DisplayName = "Map_Should_MapGroupToGroupDTO")]
        public void Map_Should_MapGroupToGroupDTO()
        {
            var entity = new Group();
            var vm = _mapper.Map<GroupDTO>(entity);

            Assert.NotNull(vm);
            Assert.IsType<GroupDTO>(vm);
        }

        [Fact(DisplayName = "Map_Should_ReverseMapGroupToGroupDTO")]
        public void Map_Should_ReverseMapGroupToGroupDTO()
        {
            var entity = new GroupDTO();
            var vm = _mapper.Map<Group>(entity);

            Assert.NotNull(vm);
            Assert.IsType<Group>(vm);
        }
    }
}