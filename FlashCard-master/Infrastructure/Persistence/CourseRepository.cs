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

        public Course GetBy(int id)
        {
            return Context.Course.FirstOrDefault(c => c.ID == id);
        }
    }
}