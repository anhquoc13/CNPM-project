using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class MemberOFDto : EntityBase
    {
        [Required]
        public string IDuser { get; set; }
        [Required]
        public int IDclass { get; set; }
    }
}