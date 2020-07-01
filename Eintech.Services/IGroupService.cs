using Eintech.Models.DTOs;
using System.Collections.Generic;

namespace Eintech.Services
{
    public interface IGroupService
    {
        List<GroupDTO> GetAll();
    }
}