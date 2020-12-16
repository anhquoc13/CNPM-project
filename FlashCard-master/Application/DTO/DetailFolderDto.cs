using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class DetailFolderDto : EntityBase
    {
        [Required]
        public int IDfolder { get; set; }
        [Required]
        public int IDcourse { get; set; }
        public int status { get; set; }
    }
}