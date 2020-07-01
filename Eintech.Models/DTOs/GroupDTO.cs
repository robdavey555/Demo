using System;
using System.ComponentModel;

namespace Eintech.Models.DTOs
{
    public class GroupDTO
    {
        public Guid Id { get; set; }

        [DisplayName("Group")]
        public string Name { get; set; }
    }
}