using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class FolderRepository : EFRepository<Folder>, IFolderRepository
    {
        public FolderRepository(FlashCardContext context) : base(context)
        {
        }
        public int Count(string id)
        {
            int count = 0;
            var query = Context.Folder.AsQueryable();
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