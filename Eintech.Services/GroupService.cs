using AutoMapper;
using Eintech.Models.DTOs;
using Eintech.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Eintech.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMapper _mapper;
        private readonly IGroupRepository _groupRepository;
        public GroupService(IMapper mapper,
                             IGroupRepository groupRepository)
        {
            _mapper = mapper;
            _groupRepository = groupRepository;
        }

        /// <summary>
        /// Get all groups
        /// </summary>
        /// <returns></returns>
        public List<GroupDTO> GetAll()
        {
            return _mapper.Map<List<GroupDTO>>(_groupRepository.GetAll().ToList());
        }
    }
}