using System.Collections.Generic;
using System.Linq;

namespace Books
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository(List<Book> books)
        {
            _books = books;
        }

        public IEnumerable<Book> RetrieveAllBooks()
        {
            return _books;
        }

        public IEnumerable<Book> RetrieveAllOrderByYearDescending()
        {
            return (from book in _books
                    orderby book.Year
                    select book);
        }

        public IEnumerable<Book> RetrieveAllOrderByYearAscending()
        {
            return (from book in _books
                orderby book.Year descending 
                select book);
        }

        public IEnumerable<Book> RetrieveAllOrderByPriceAscending()
        {
            return (from book in _books
                orderby book.Price
                select book);
        }

        public IEnumerable<Book> RetrieveAllOrderByPriceDescending()
        {
            return (from book in _books
                orderby book.Price descending
                select book);
        }

        public IEnumerable<IGrouping<Genres, Book>> RetrieveAllBooksGroupedByGenre()
        {
            return (from book in _books
                group book by book.Genres);
        }
    }
}