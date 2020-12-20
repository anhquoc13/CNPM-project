using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class VocalbularyDto
    {
        public int ID { get; set; }
        public string define { get; set; }
        public string explain { get; set; }
        public string image { get; set; }
        public string result { get; set; }
    }
}