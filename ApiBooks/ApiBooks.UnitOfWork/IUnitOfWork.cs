using ApiBooks.Repositories;

namespace ApiBooks.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBooksRepository Books { get; set; }
    }
}
