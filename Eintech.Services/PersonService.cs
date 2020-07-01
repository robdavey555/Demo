using AutoMapper;
using Eintech.Models;
using Eintech.Models.DTOs;
using Eintech.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Eintech.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;

        public PersonService(IMapper mapper, 
                             IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        /// <summary>
        /// Search people by name OR group
        /// </summary>
        /// <param name="searchName"></param>
        /// <param name="searchGroup"></param>
        /// <returns></returns>
        public List<PersonDTO> Search(string searchName, string searchGroup)
        {
            return _mapper.Map<List<PersonDTO>>(_personRepository.Search(x => x.Name.Contains(searchName) || 
                                                                         x.Group.Name.Contains(searchGroup)).ToList());
        }

        /// <summary>
        /// Get all people
        /// </summary>
        /// <returns></returns>
        public List<PersonDTO> GetAll()
        {
            return _mapper.Map<List<PersonDTO>>(_personRepository.GetAll(d => d.Group).ToList());
        }

        /// <summary>
        /// Add person
        /// </summary>
        /// <param name="person"></param>
        public void Add(PersonDTO person)
        {
            if (string.IsNullOrEmpty(person.Name))
                throw new ArgumentException("Person name cannot be empty");

            _personRepository.Add(_mapper.Map<Person>(person));            
        }
    }
}