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

        public void Remove(Book book)
        {
            _repository.Remove(book);
        }

        public void Update(int id, Book book)
        {
            _repository.Update(id, book);
        }

        public IEnumerable<Book> GetBooksByName(string filter)
        {
            return _repository.GetAll().Where(b => b.Name.ToLower().Contains(filter.ToLower()));
        }

        public IEnumerable<Book> GetBooksByAuthor(string filter)
        {
            return _repository.GetAll().Where(b => b.Author.ToLower().Contains(filter.ToLower()));
        }

        public IEnumerable<Book> GetBooksByGenre(string filter)
        {
            return _repository.GetAll().Where(b => b.Genre.ToLower().Contains(filter.ToLower()));
        }

        public IEnumerable<Book> GetBooksWithZeroNumber()
        {
            return GetAllBooks().Where(b => b.Number == 0);
        }

        public IEnumerable<Book> GetTop3MostPopularBooksThisMonth()
        {
            return GetAllBooks().Where(b => b.Lendings.Count() > 0)
                                .Where(b => b.Lendings.First().IssueDate.Month == DateTime.Now.Month)
                                .OrderByDescending(b => b.Lendings.Count())
                                .Take(3);
        }
    }
}