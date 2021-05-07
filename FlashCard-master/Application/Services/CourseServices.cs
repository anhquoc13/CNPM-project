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

        public IEnumerable<VocabularyDto> GetVocabulary(int id)
        {
            return _courseRepository.GetVocabulary(id).MappingDto();
        }

        public IEnumerable<CourseDto> GetCoureList(string userID)
        {
            return _courseRepository.GetCoureList(userID).MappingDto();
        }

        public int GetNewestID()
        {
            return _courseRepository.GetNewestID();
        }

        public int CourseCount(string id)
        {
            return _courseRepository.Count(id);
        }

        public void CreateCourse(CourseDto CourseDto)
        {
            var courseToCreate = CourseMapper.MappingCourse(CourseDto);
            _courseRepository.Add(courseToCreate);
        }

        public void UpdateCourse(CourseDto CourseDto)
        {
            var courseToUpdate = CourseMapper.MappingCourse(CourseDto);
            _courseRepository.Update(courseToUpdate);
        }

        public void DeleteCourse(int id)
        {
            var courseToDelete = _courseRepository.GetBy(id);
            _courseRepository.Remove(courseToDelete);
        }
    }
}