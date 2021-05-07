using System.Collections.Generic;
using Application.DTO;

namespace Application.Interfaces
{
    public interface ICourseServices
    {
        CourseDto GetBy(int id);      
        IEnumerable<CourseDto> GetAll();
        IEnumerable<VocabularyDto> GetVocabulary(int id);
        IEnumerable<CourseDto> GetCoureList(string userID);
        int GetNewestID();
        int CourseCount(string id);
        void CreateCourse(CourseDto courseDto);
        void UpdateCourse(CourseDto courseDto);
        void DeleteCourse(int id);
        bool CourseExists(int id);
    }
}