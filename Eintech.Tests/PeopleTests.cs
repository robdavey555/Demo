using Eintech.Data.Extensions;
using Eintech.Models;
using Eintech.Models.DTOs;
using Eintech.Repositories;
using Eintech.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Eintech.Tests
{
    public class PeopleTests : _TestBase
    {
        private Mock<IPersonRepository> _mockPersonRepository;
        
        private IPersonService _sut;

        public PeopleTests()
        {
            _mockPersonRepository = new Mock<IPersonRepository>();

            _sut = new PersonService(_mapper, _mockPersonRepository.Object);            
        }

        [Fact(DisplayName = "PersonService_GetAll_NotNull")]
        public void PersonService_GetAll_NotNull()
        {
            //Arrange
            var fakePeople = Fakers.People.AsQueryable();
            _mockPersonRepository.Setup(x => x.GetAll(x => x.Group)).Returns(fakePeople);

            //Act
            var people = _sut.GetAll();

            //Assert
            Assert.NotNull(people);
        }

        [Fact(DisplayName = "PersonService_GetAll_CountMatches")]
        public void PersonService_GetAll_CountMatches()
        {
            //Arrange
            var fakePeople = Fakers.People.AsQueryable();
            _mockPersonRepository.Setup(x => x.GetAll(x => x.Group)).Returns(fakePeople);

            //Act
            var people = _sut.GetAll();

            //Assert
            Assert.Equal(_mapper.Map<List<PersonDTO>>(Fakers.People).Count, people.Count);
        }

        /// <summary>
        /// Ensure that Include works and group navigation property is loaded
        /// </summary>
        [Fact(DisplayName = "PersonService_GetAll_HasGroupLoaded")]
        public void PersonService_GetAll_HasGroupLoaded()
        {
            //Arrange
            var fakePeople = Fakers.People.AsQueryable();
            _mockPersonRepository.Setup(x => x.GetAll(x => x.Group)).Returns(fakePeople);

            //Act
            var people = _sut.GetAll();

            //Assert
            Assert.NotNull(people.FirstOrDefault().Group);            
        }

        [Fact(DisplayName = "PersonService_SearchByName_NotNull")]
        public void PersonService_SearchByName_NotNull()
        {
            //Arrange
            var searchName = Fakers.People.First().Name;
            var fakePeople = Fakers.People.Where(s => s.Name.Contains(searchName)).AsQueryable();

            _mockPersonRepository.Setup(x => x.Search(x => x.Name.Contains(searchName))).Returns(fakePeople);

            //Act
            var people = _sut.Search(searchName, "");

            //Assert
            Assert.NotNull(people);
        }

        [Fact(DisplayName = "PersonService_SearchByName_ContainsMatch")]
        public void PersonService_SearchByName_ContainsMatch()
        {
            //Arrange
            var searchName = Fakers.People.First().Name;
            var fakePeople = Fakers.People.Where(s => s.Name.Contains(searchName)).AsQueryable();

            _mockPersonRepository.Setup(x => x.Search(x => x.Name.Contains(searchName)))
                                    .Returns(fakePeople);

            //Act
            var people = _sut.Search(searchName, "");

            //Assert
            foreach (var p in people)
            {
                Assert.Contains(searchName, p.Name);
            }
        }

        [Fact(DisplayName = "PersonService_AddPerson_Valid")]
        public void PersonService_AddPerson_Valid()
        {
            //Arrange
            var fakeGroups = Fakers.Groups;
            _mockPersonRepository.Setup(x => x.Add(It.IsAny<Person>()));

            var newPerson = new PersonDTO()
            {
                GroupId = fakeGroups.First().Id,
                Name = "Test Name"
            };

            //Act
            _sut.Add(newPerson);

            //Assert
            _mockPersonRepository.Verify(r => r.Add(It.IsAny<Person>()));
        }

        [Fact(DisplayName = "PersonService_AddPerson_EmptyNameFail")]
        public void PersonService_AddPerson_EmptyNameFail()
        {
            //Arrange
            var fakeGroups = Fakers.Groups;
            _mockPersonRepository.Setup(x => x.Add(It.IsAny<Person>()));

            var newPerson = new PersonDTO()
            {
                GroupId = fakeGroups.First().Id,
                Name = ""
            };

            //Assert
            Assert.Throws<ArgumentException>(() => _sut.Add(newPerson));
        }
    }
}