using System;

namespace Entities.Models
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }

    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}