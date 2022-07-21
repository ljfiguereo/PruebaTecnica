using System.Collections.Generic;

namespace ApiBooks.Repositories
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetList();
        T GetById(int id);
        int Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
