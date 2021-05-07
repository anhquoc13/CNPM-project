using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Mappings
{
    public static class VocabularyMapper
    {
        public static VocabularyDto MappingDto(this Vocabulary Vocabulary)
        {
            return new VocabularyDto
            {
                ID = Vocabulary.ID,
                define = Vocabulary.define,
                explain = Vocabulary.explain,
                image = Vocabulary.image
            };
        }

        public static Vocabulary MappingVocabulary(this VocabularyDto VocabularyDto)
        {
            return new Vocabulary
            {
                ID = VocabularyDto.ID,
                define = VocabularyDto.define,
                explain = VocabularyDto.explain,
                image = VocabularyDto.image
            };
        }

        public static void MappingVocabulary(this VocabularyDto VocabularyDto, Vocabulary Vocabulary)
        {
            Vocabulary.ID = VocabularyDto.ID;
            Vocabulary.define = VocabularyDto.define;
            Vocabulary.explain = VocabularyDto.explain;
            Vocabulary.image = VocabularyDto.image;
        }

        public static IEnumerable<VocabularyDto> MappingDto(this IEnumerable<Vocabulary> Vocabularies)
        {
            foreach (var Vocabulary in Vocabularies)
            {
                yield return Vocabulary.MappingDto();
            }
        }

        public static IEnumerable<Vocabulary> MappingVocabulary(this IEnumerable<VocabularyDto> VocabularyDto)
        {
            foreach (var vocabularyDto in VocabularyDto)
            {
                yield return vocabularyDto.MappingVocabulary();
            }
        }

    }
}
