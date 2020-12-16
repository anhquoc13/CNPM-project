using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        Course GetBy(int id);
    }
}