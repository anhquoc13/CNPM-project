using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class ListVocabularyRepository : EFRepository<listVocabulary>, IListVocabularyRepository
    {
        public ListVocabularyRepository(FlashCardContext context) : base(context)
        {
        }

        public int GetNewestID()
        {
            var query = Context.listVocabulary.AsQueryable();
            return query.OrderByDescending(lv => lv.ID).FirstOrDefault().ID;
        }
    }
}