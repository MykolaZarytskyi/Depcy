using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Dependency.Models
{
    public class ModelFirstDBContext:DbContext
    {
        public ModelFirstDBContext() : base("name=PlutoContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual  DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
    }
}