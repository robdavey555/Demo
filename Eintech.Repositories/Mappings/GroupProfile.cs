using AutoMapper;
using Eintech.Models;
using Eintech.Models.DTOs;

namespace Eintech.Repositories.Mappings
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            CreateMap<Group, GroupDTO>()
                .ReverseMap()
                ;
        }
    }
}