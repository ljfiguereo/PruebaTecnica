using ApiBooks.Models;
using ApiBooks.Repositories;

namespace ApiBooks.DataAccess
{
    public class BooksRepository : Repository<Books>, IBooksRepository
    {
        public BooksRepository(string connectionString):base(connectionString)
        {

        }
    }
}
