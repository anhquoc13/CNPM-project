using System.Collections.Generic;
using Application.DTO;
using Application.Interfaces;
using Application.Mappings;
using Domain.Repositories;
using Domain.Entities;

namespace Application.Services
{
    public class VocabularyServices : IVocabularyServices
    {
        private readonly IVocabularyRepository _vocabularyRepository;
        private readonly IListVocabularyRepository _listVocabularyRepository;

        public VocabularyServices(IVocabularyRepository vocabularyRepository, IListVocabularyRepository listVocabularyRepository)
        {
            _vocabularyRepository = vocabularyRepository;
            _listVocabularyRepository = listVocabularyRepository;
        }

        public int VocabularyCount(int id)
        {
            return _vocabularyRepository.Count(id);
        }

        public int GetNewestID()
        {
            return _vocabularyRepository.GetNewestID();
        }

        public void CreateListVocabulary(int idcourse, int idvocab)
        {
            ListVocabularyDto listVocabulary = new ListVocabularyDto()
            {
                IDcourse = idcourse,
                IDvocab = idvocab
            };

            var listVocabularyToCreate = ListVocabularyMapper.MappingListVocabulary(listVocabulary);
            _listVocabularyRepository.Add(listVocabularyToCreate);
        }

        public void CreateVocabulary(VocabularyDto VocabularyDto)
        {
            var vocabularyToCreate = VocabularyMapper.MappingVocabulary(VocabularyDto);
            _vocabularyRepository.Add(vocabularyToCreate);
        }

        public void UpdateVocabulary(VocabularyDto VocabularyDto)
        {
            var vocabularyToUpdate = VocabularyMapper.MappingVocabulary(VocabularyDto);
            _vocabularyRepository.Update(vocabularyToUpdate);
        }

        public void DeleteVocabulary(int id)
        {
            var vocabularyToDelete = _vocabularyRepository.GetBy(id);
            _vocabularyRepository.Remove(vocabularyToDelete);
        }
    }
}