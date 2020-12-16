using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class TestOFCourseDto : EntityBase
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int IDcourse { get; set; }
        [Required]
        public float scores { get; set; }
    }
}