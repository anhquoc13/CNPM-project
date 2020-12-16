using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetBy(string id);
        IEnumerable<string> GetRoles();
        IEnumerable<User> Filter(string sortOrder, string userRole, string searchString, int pageIndex, int pageSize, out int count);
    }
}