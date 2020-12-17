using Application.DTO;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.ViewModels
{
    public class SetsViewModel
    {
        public User user { get; set; }
        public IEnumerable<VocalbularyDto> answer { get; set; }
    }
}