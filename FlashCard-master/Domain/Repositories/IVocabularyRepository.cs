using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IVocabularyRepository : IRepository<Vocabulary>
    {
        int Count(int id);
        int GetNewestID();
    }
}