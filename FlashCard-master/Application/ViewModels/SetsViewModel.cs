using Application.DTO;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class SetsViewModel
    {
        public int ID { get; set; }
        public User user { get; set; }
        public IEnumerable<VocalbularyDto> question { get; set; }
        public IEnumerable<VocalbularyDto> answer { get; set; }
        public bool IsFinish { get; set; }
        public int CorrectCount { get; set; }
        public int QuestionCount { get; set; }
        public float Point { get; set; }
    }
}