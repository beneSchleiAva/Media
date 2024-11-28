using System.ComponentModel.DataAnnotations;

namespace Persistence.Entities.Abstract
{
    internal interface IEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
