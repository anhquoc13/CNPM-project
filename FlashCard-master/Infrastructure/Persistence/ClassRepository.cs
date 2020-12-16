using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class ClassRepository : EFRepository<Class>, IClassRepository
    {
        public ClassRepository(FlashCardContext context) : base(context)
        {
        }

        public Class GetBy(int id)
        {
            return Context.Class.FirstOrDefault(c => c.ID == id);
        }
    }
}