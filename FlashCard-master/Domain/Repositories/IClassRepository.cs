using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        int Count(string id);
    }
}