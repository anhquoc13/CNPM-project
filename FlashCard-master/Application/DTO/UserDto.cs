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
        public string email { get; set; }
        [Required]
        public string role { get; set; }
        public int CourseCount { get; set; }
        public int FolderCount { get; set; }
        public int ClassCount { get; set; }
    }
}