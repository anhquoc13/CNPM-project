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
            query = query.Where(m => m.IDuser == id);
            foreach (var course in query)
            {
                if (course.IDuser == id)
                {
                    count++;
                }
            }
            return count;
        }
    }
}