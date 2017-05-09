using Dependency.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Dependency.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ModelFirstDBContext MFDBContext = null;
        public Repository(ModelFirstDBContext dBContext)
        {
            MFDBContext = dBContext;
        }
        public async Task<List<T>> GetAll()
        {
            return await MFDBContext.Set<T>().ToListAsync();
        }
        public async Task<T> Get(Func<T, bool> predicate)
        {
            return await MFDBContext.Set<T>().FindAsync(predicate);
        }
        public async Task<T> FindByIdAsync(int id)
        {
            return await MFDBContext.Set<T>().FindAsync(id);
        }
        public async void Create(T item)
        {
            MFDBContext.Set<T>().Add(item);
            await MFDBContext.SaveChangesAsync();
        }
        public async void Delete(T item)
        {
            MFDBContext.Set<T>().Remove(item);
            await MFDBContext.SaveChangesAsync();
        }
        public async void Update(T item)
        {
            MFDBContext.Entry(item).State = EntityState.Modified;
            await MFDBContext.SaveChangesAsync();
        }
    }

    public class BookRepository : Repository<Book>
    {
        public BookRepository(ModelFirstDBContext dBContext) : base(dBContext)
        {
        }
    }

    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(ModelFirstDBContext dBContext) : base(dBContext)
        {
        }
    }
}
