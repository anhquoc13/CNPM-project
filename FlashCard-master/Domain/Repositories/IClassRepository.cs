using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        Class GetBy(int id);
    }
}