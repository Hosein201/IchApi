using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Company : BaseEntity
    {
        [Key]

        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}