using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Mappings
{
    public static class CourseMapper
    {
        public static CourseDto MappingDto(this Course Course)
        {
            return new CourseDto
            {
                ID = Course.ID,
                IDuser = Course.IDuser,
                name = Course.name,
                describe = Course.describe,
                link = Course.link
            };
        }

        public static Course MappingCourse(this CourseDto CourseDto)
        {
            return new Course
            {
                ID = CourseDto.ID,
                IDuser = CourseDto.IDuser,
                name = CourseDto.name,
                describe = CourseDto.describe,
                link = CourseDto.link
            };
        }

        public static void MappingCourse(this CourseDto CourseDto, Course Course)
        {
            Course.ID = CourseDto.ID;
            Course.IDuser = CourseDto.IDuser;
            Course.name = CourseDto.name;
            Course.describe = CourseDto.describe;
            Course.link = CourseDto.link;
        }

        public static IEnumerable<CourseDto> MappingDto(this IEnumerable<Course> Courses)
        {
            foreach (var Course in Courses)
            {
                yield return Course.MappingDto();
            }
        }

        public static IEnumerable<Course> MappingCourse(this IEnumerable<CourseDto> CourseDtos)
        {
            foreach (var CourseDto in CourseDtos)
            {
                yield return CourseDto.MappingCourse();
            }
        }

    }
}
