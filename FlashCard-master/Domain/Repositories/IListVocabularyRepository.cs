using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IListVocabularyRepository : IRepository<listVocabulary>
    {
        int GetNewestID();
    }
}