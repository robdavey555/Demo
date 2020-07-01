using Eintech.Models;
using Eintech.Models.DTOs;
using System.Collections.Generic;

namespace Eintech.App.Models
{
    public class PeopleViewModel
    {
        public List<PersonDTO> People { get; set; } = new List<PersonDTO>();
    }
}