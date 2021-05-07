using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        int Count(string id);
        int GetNewestID();
        IEnumerable<Vocabulary> GetVocabulary(int id);
        IEnumerable<Course> GetCoureList(string userID);
    }
}