using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class VocalbularyDto : EntityBase
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string define { get; set; }
        [Required]
        public string explain { get; set; }
        public string image { get; set; }
    }
}