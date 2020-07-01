using Eintech.Models.DTOs;
using System.Collections.Generic;

namespace Eintech.Services
{
    public interface IPersonService
    {
        List<PersonDTO> GetAll();

        List<PersonDTO> Search(string searchName, string searchGroup);

        void Add(PersonDTO person);
    }
}