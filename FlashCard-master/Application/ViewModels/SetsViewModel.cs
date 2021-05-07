using Application.DTO;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class SetsViewModel
    {
        public int ID { get; set; }
        public User user { get; set; }
        public string Name { get; set; }
        public string Describe { get; set; }
        public string Image { get; set; }
        public int count { get; set; }
        public List<string> Term { get; set; }
        public List<string> DescribeTerm { get; set; }
    }
}
