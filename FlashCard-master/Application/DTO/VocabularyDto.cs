using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class VocabularyDto
    {
        public int ID { get; set; }
        public string define { get; set; }
        public string explain { get; set; }
        public string image { get; set; }
    }
}