using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class CourseRepository : EFRepository<Course>, ICourseRepository
    {
        public CourseRepository(FlashCardContext context) : base(context)
        {
        }
        public int Count(string id)
        {
            int count = 0;
            var query = Context.Course.AsQueryable();
            query = query.Where(c => c.IDuser == id);
            foreach (var course in query)
            {
                if (course.IDuser == id)
                {
                    count++;
                }
            }
            return count;
        }

        public IEnumerable<Vocabulary> GetVocabulary(int id)
        {
            var listVocabulary = Context.listVocabulary.AsQueryable();
            listVocabulary = listVocabulary.Where(l => l.IDcourse == id);
            List<Vocabulary> vocabulary = new List<Vocabulary>();
            foreach (var item in listVocabulary)
            {
                vocabulary.Add(Context.Vocabulary.FirstOrDefault(v => v.ID == item.IDvocab));
            }
            return vocabulary;
        }

        public int GetNewestID()
        {
            var query = Context.Course.AsQueryable();
            return query.OrderByDescending(v => v.ID).FirstOrDefault().ID;
        }

        public IEnumerable<Course> GetCoureList(string userID)
        {
            var query = Context.Course.AsQueryable();
            return query.Where(c => c.IDuser == userID);
        }
    }
}