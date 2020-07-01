using AutoMapper;
using Eintech.Models;
using Eintech.Models.DTOs;

namespace Eintech.Repositories.Mappings
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonDTO>()
                .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group))
                .ReverseMap()
                ;
        }
    }
}