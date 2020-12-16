using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class TestOfFolder : EntityBase, IAggregateRoot
    {
        [Key]
        public int ID { get; set; }
        public int IDgrfolder { get; set; }
        public float scores { get; set; }
    }
}