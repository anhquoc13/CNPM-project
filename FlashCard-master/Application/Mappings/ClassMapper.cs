using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ClassMapper
    {
        public static ClassDto MappingDto(this Class Class)
        {
            return new ClassDto
            {
                ID = Class.ID,
                IDuser = Class.IDuser,
                name = Class.name,
                describe = Class.describe,
                link = Class.link
            };
        }

        public static Class MappingClass(this ClassDto ClassDto)
        {
            return new Class
            {
                ID = ClassDto.ID,
                IDuser = ClassDto.IDuser,
                name = ClassDto.name,
                describe = ClassDto.describe,
                link = ClassDto.link
            };
        }

        public static void MappingClass(this ClassDto ClassDto, Class Class)
        {
            Class.ID = ClassDto.ID;
            Class.IDuser = ClassDto.IDuser;
            Class.name = ClassDto.name;
            Class.describe = ClassDto.describe;
            Class.link = ClassDto.link;
        }

        public static IEnumerable<ClassDto> MappingDto(this IEnumerable<Class> Classes)
        {
            foreach (var Class in Classes)
            {
                yield return Class.MappingDto();
            }
        }

        public static IEnumerable<Class> MappingClass(this IEnumerable<ClassDto> ClassDtos)
        {
            foreach (var ClassDto in ClassDtos)
            {
                yield return ClassDto.MappingClass();
            }
        }

    }
}
