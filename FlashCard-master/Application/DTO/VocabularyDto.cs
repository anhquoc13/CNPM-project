using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class VocalbularyDto : EntityBase
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Biệt danh không được phép để trống")]
        public string define { get; set; }
        public string explain { get; set; }
        public string image { get; set; }
    }
}