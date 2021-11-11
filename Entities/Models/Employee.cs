using System;

namespace Entities.Models
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public Guid CompanyId { get; set; }
        public Company Company { get; set; }
    }
}