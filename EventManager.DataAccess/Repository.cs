using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManager.DataAccess
{
    public class Repository<T> : IRepository<T> where T: EntityBase
    {
        private readonly EventStorageDbContext context;
        private DbSet<T> _entities;

        public Repository(EventStorageDbContext context)
        {
            this.context = context;
            _entities = context.Set<T>();
        }


        public Task<List<T>> GetAll()
        {
            return _entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return _entities.SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task Insert(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Add(entity);
            return context.SaveChangesAsync();
        }

        public Task Update(T entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException("entity");
            }
            return context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await _entities.SingleOrDefaultAsync(e => e.Id == id);
            _entities.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
