using Eintech.Data.Extensions;
using Eintech.Repositories;
using Moq;
using Eintech.Services;
using System.Linq;
using Xunit;

namespace Eintech.Tests
{
    public class GroupTests : _TestBase
    {
        private Mock<IGroupRepository> _mockGroupRepository;

        private IGroupService _sut;

        public GroupTests()
        {
            _mockGroupRepository = new Mock<IGroupRepository>();

            _sut = new GroupService(_mapper, _mockGroupRepository.Object);
        }

        [Fact(DisplayName = "GroupService_GetAll_NotNull")]
        public void GroupService_GetAll_NotNull()
        {
            //Arrange
            var fakeGroups = Fakers.Groups.ToList().AsQueryable();
            _mockGroupRepository.Setup(x => x.GetAll()).Returns(fakeGroups);

            //Act
            var groups = _sut.GetAll();

            //Assert
            Assert.NotNull(groups);
        }

        [Fact(DisplayName = "GroupService_GetAll_CountMatches")]
        public void GroupService_GetAll_CountMatches()
        {
            //Arrange
            var fakeGroups = Fakers.Groups.ToList().AsQueryable();
            _mockGroupRepository.Setup(x => x.GetAll()).Returns(fakeGroups);

            //Act
            var groups = _sut.GetAll();

            //Assert
            Assert.Equal(Fakers.Groups.Count, groups.Count);
        }
    }
}