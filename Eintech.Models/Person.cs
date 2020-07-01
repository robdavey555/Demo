using System;

namespace Eintech.Models
{
    public class Person : _Base
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid GroupId { get; set; }

        public Group Group { get; set; }
    }
}