using ApiBooks.Repositories;
using ApiBooks.UnitOfWork;

namespace ApiBooks.DataAccess
{
    public class ApiBooksUoW : IUnitOfWork
    {
        public ApiBooksUoW(string connectionString)
        {
            Books = new BooksRepository(connectionString);
        }
        public IBooksRepository Books { get; set; }
    }
}
