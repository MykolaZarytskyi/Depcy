using Dependency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dependency.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModelFirstDBContext _context;

        public UnitOfWork(ModelFirstDBContext context)
        {
            _context = context;
            Books = new BookRepository(_context);
            Authors = new AuthorRepository(_context);
        }

        public IRepository<Book> Books { get; private set; }
        public IRepository<Author> Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}