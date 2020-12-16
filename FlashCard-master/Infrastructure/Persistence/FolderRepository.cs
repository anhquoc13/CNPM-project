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

        public Folder GetBy(int id)
        {
            return Context.Folder.FirstOrDefault(f => f.ID == id);
        }
    }
}