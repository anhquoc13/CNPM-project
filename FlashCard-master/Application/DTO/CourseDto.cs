using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CourseDto : EntityBase
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string IDuser { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string name { get; set; }
        public string describe { get; set; }
        public string link { get; set; }
    }
}