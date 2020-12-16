using System.Collections.Generic;
using System.Linq;
using Domain.Entities.Common;
using Domain.Repositories;

namespace Infrastructure.Persistence
{
    public class EFRepository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly FlashCardContext _context;

        public EFRepository(FlashCardContext context)
        {
            _context = context;
        }

        protected FlashCardContext Context => _context;

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public int Count()
        {
            return _context.Set<T>().Count();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetBy(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}