using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Vocalbulary : EntityBase, IAggregateRoot
    {
        [Key]
        public int ID { get; set; }
        public string define { get; set; }
        public string explain { get; set; }
        public string image { get; set; }
    }
}