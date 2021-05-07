using System.Collections.Generic;
using Application.DTO;
using Domain.Entities;

namespace Application.Mappings
{
    public static class ListVocabularyMapper
    {
        public static ListVocabularyDto MappingDto(this listVocabulary listVocabulary)
        {
            return new ListVocabularyDto
            {
                ID = listVocabulary.ID,
                IDcourse = listVocabulary.IDcourse,
                IDvocab = listVocabulary.IDvocab,
            };
        }

        public static listVocabulary MappingListVocabulary(this ListVocabularyDto ListVocabularyDto)
        {
            return new listVocabulary
            {
                ID = ListVocabularyDto.ID,
                IDcourse = ListVocabularyDto.IDcourse,
                IDvocab = ListVocabularyDto.IDvocab,
            };
        }

        public static void MappingListVocabulary(this ListVocabularyDto ListVocabularyDto, listVocabulary listVocabulary)
        {
            listVocabulary.ID = ListVocabularyDto.ID;
            listVocabulary.IDcourse = ListVocabularyDto.IDcourse;
            listVocabulary.IDvocab = ListVocabularyDto.IDvocab;
        }

        public static IEnumerable<ListVocabularyDto> MappingDto(this IEnumerable<listVocabulary> listVocabularies)
        {
            foreach (var listVocabulary in listVocabularies)
            {
                yield return listVocabulary.MappingDto();
            }
        }

        public static IEnumerable<listVocabulary> MappingListVocabulary(this IEnumerable<ListVocabularyDto> ListVocabularyDto)
        {
            foreach (var listVocabularyDto in ListVocabularyDto)
            {
                yield return listVocabularyDto.MappingListVocabulary();
            }
        }

    }
}
