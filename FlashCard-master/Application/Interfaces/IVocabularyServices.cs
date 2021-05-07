using System.Collections.Generic;
using Application.DTO;

namespace Application.Interfaces
{
    public interface IVocabularyServices
    {   
        int VocabularyCount(int id);
        int GetNewestID();
        void CreateListVocabulary(int idcourse, int idvocab);
        void CreateVocabulary(VocabularyDto vocalbularyDto);
        void UpdateVocabulary(VocabularyDto vocalbularyDto);
        void DeleteVocabulary(int id);
    }
}