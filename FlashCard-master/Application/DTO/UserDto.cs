using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class UserDto : EntityBase
    {
        [Key]
        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string ID { get; set; }
        [StringLength(30, MinimumLength = 5)]
        [Required]
        public string tagname { get; set; }
        [Required]
        public string avatar { get; set; }
    }
}