using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Eintech.Models.DTOs
{
    public class PersonDTO
    {
        [DisplayName("Person Id")]
        public Guid Id { get; set; }

        [Required]

        [DisplayName("Person Name")]
        public string Name { get; set; }

        [Required]
        public Nullable<Guid> GroupId { get; set; }

        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }

        public GroupDTO Group { get; set; }
    }
}