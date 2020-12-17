using System.Collections.Generic;
using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepository _courseRepository;

        public CourseServices(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public bool CourseExists(int id)
        {
            var course = _courseRepository.GetBy(id);
            return course != null;
        }

        public CourseDto GetBy(int id)
        {
            return _courseRepository.GetBy(id).MappingDto();
        }

        public IEnumerable<CourseDto> GetAll()
        {
            return _courseRepository.GetAll().MappingDto();
        }

        public int CourseCount(string id)
        {
            return _courseRepository.Count(id);
        }

        public void CreateCourse(CourseDto CourseDto)
        {
            var courseToCreate = _courseRepository.GetBy(CourseDto.ID);
            _courseRepository.Add(courseToCreate);
        }

        public void UpdateCourse(CourseDto CourseDto)
        {
            var courseToUpdate = _courseRepository.GetBy(CourseDto.ID);
            _courseRepository.Update(courseToUpdate);
        }

        public void DeleteCourse(int id)
        {
            var courseToDelete = _courseRepository.GetBy(id);
            _courseRepository.Remove(courseToDelete);
        }
    }
}