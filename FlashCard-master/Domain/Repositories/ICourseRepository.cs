using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        int Count(string id);
        IEnumerable<Vocabulary> GetVocalbulary(int id);
    }
}