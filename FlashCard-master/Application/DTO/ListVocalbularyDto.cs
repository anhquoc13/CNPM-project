using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class ListVocalbularyDto : EntityBase
    {
        public int ID { get; set; }
        [Required]
        public int IDcourse { get; set; }
        [Required]
        public int IDvocab { get; set; }
    }
}