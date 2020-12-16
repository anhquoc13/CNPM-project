using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        public UserRepository(FlashCardContext context) : base(context)
        {
        }

        public User GetBy(string id)
        {
            return Context.User.FirstOrDefault(u => u.ID == id);
        }
        
        public IEnumerable<string> GetRoles()
        {
            return Context.User
                .OrderBy(m => m.role)
                .Select(m => m.role)
                .Distinct();
        }

        public IEnumerable<User> Filter(string sortOrder, string userRole, string searchString, int pageIndex, int pageSize, out int count)
        {
            var query = Context.User.AsQueryable();

            if (!string.IsNullOrEmpty(userRole))
            {
                query = query.Where(m => m.role == userRole);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(m => m.ID.Contains(searchString));
            }

            SortUser(sortOrder, ref query);
            count = query.Count();

            return query.Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();
        }

        private static void SortUser(string sortOrder, ref IQueryable<User> query)
        {
            switch (sortOrder)
            {
                case "ID_desc":
                    query = query.OrderByDescending(m => m.ID);
                    break;
                case "ID":
                    query = query.OrderBy(m => m.ID);
                    break;
                case "createdDay_desc":
                    query = query.OrderByDescending(m => m.createdDay);
                    break;
                case "createdDay":
                    query = query.OrderBy(m => m.createdDay);
                    break;
                case "role_desc":
                    query = query.OrderByDescending(m => m.role);
                    break;
                case "role":
                    query = query.OrderBy(m => m.role);
                    break;
                case "status_desc":
                    query = query.OrderByDescending(m => m.status);
                    break;
                case "status":
                    query = query.OrderBy(m => m.status);
                    break;
            }
        }
    }
}