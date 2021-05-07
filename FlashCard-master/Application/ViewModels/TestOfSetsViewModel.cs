using Application.DTO;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class TestOfSetsViewModel
    {
        public int ID { get; set; }
        public User user { get; set; }
        public CourseDto course { get; set; }
        public string name { get; set; }
        public IEnumerable<VocabularyDto> question { get; set; }
        public List<string> answer { get; set; }
        public List<bool> result { get; set; }
        public bool IsFinish { get; set; }
        public float CorrectCount { get; set; }
        public float QuestionCount { get; set; }
        public float Point { get; set; }
    }
}