using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class GroupFolderDto : EntityBase
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int IDfolder { get; set; }
        [Required]
        public int IDclass { get; set; }
        public int status { get; set; }
    }
}