using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFolderRepository : IRepository<Folder>
    {
        Folder GetBy(int id);
    }
}