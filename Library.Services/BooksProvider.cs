using Library.DAL.SQL.Entity;
using Library.DAL.SQL.Repositories;

namespace Library.Services
{
    public class BooksProvider
    {
        private readonly IRepository<Book> _repository;

        public BooksProvider(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public void AddBook(Book book)
        {
            _repository.Add(book);
        }

        public void AddBooks(List<Book> books)
        {
            books.ForEach(book => _repository.Add(book));
        }

        public Book GetBookByID(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _repository.GetAll();
        }
    }
}