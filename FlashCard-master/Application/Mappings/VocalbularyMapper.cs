using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Mappings
{
    public static class VocalbularyMapper
    {
        public static VocalbularyDto MappingDto(this Vocabulary Vocabulary)
        {
            return new VocalbularyDto
            {
                ID = Vocabulary.ID,
                define = Vocabulary.define,
                explain = Vocabulary.explain,
                image = Vocabulary.image
            };
        }

        public static Vocabulary MappingCourse(this VocalbularyDto VocalbularyDto)
        {
            return new Vocabulary
            {
                ID = VocalbularyDto.ID,
                define = VocalbularyDto.define,
                explain = VocalbularyDto.explain,
                image = VocalbularyDto.image
            };
        }

        public static void MappingCourse(this VocalbularyDto VocalbularyDto, Vocabulary Vocabulary)
        {
            Vocabulary.ID = VocalbularyDto.ID;
            Vocabulary.define = VocalbularyDto.define;
            Vocabulary.explain = VocalbularyDto.explain;
            Vocabulary.image = VocalbularyDto.image;
        }

        public static IEnumerable<VocalbularyDto> MappingDto(this IEnumerable<Vocabulary> Vocalbularies)
        {
            foreach (var Vocabulary in Vocalbularies)
            {
                yield return Vocabulary.MappingDto();
            }
        }

        public static IEnumerable<Vocabulary> MappingCourse(this IEnumerable<VocalbularyDto> VocalbularyDto)
        {
            foreach (var vocalbularyDto in VocalbularyDto)
            {
                yield return vocalbularyDto.MappingCourse();
            }
        }

    }
}
