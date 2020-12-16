using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class TestOfFolderDto : EntityBase
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int IDgrfolder { get; set; }
        [Required]
        public float scores { get; set; }
    }
}