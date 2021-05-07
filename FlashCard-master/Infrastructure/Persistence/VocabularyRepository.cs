using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class VocabularyRepository : EFRepository<Vocabulary>, IVocabularyRepository
    {
        public VocabularyRepository(FlashCardContext context) : base(context)
        {
        }
        public int Count(int id)
        {
            int count = 0;
            var query = Context.Vocabulary.AsQueryable();
            query = query.Where(m => m.ID == id);
            foreach (var vocabulary in query)
            {
                if (vocabulary.ID == id)
                {
                    count++;
                }
            }
            return count;
        }

        public int GetNewestID()
        {
            var query = Context.Vocabulary.AsQueryable();
            return query.OrderByDescending(v => v.ID).FirstOrDefault().ID;
        }
    }
}