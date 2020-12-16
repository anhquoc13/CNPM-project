using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.Common
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}