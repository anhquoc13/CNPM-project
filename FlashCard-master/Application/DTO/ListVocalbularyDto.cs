using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class ListVocalbularyDto : EntityBase
    {
        [Required]
        public int IDcourse { get; set; }
        [Required]
        public int IDvocab { get; set; }
    }
}