using System.Collections.Generic;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ICourseServices
    {
        CourseDto GetBy(int id);
        IEnumerable<CourseDto> GetAll();
        void CreateCourse(CourseDto courseDto);
        void UpdateCourse(CourseDto courseDto);
        void DeleteCourse(int id);
        bool CourseExists(int id);
    }
}