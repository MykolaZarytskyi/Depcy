using Dependency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency.Repositories
{
    public interface IRepository<T>  where T : class
    {
        Task<List<T>> GetAll(); // получение всех объектов
        Task<T> FindByIdAsync(int id);
        Task<T> Get(Func<T, bool> predicate); // получение одного объекта по
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(T item); // удаление объекта 
    }

    public interface IUnitOfWork : IDisposable
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        int Complete();
    }
}
