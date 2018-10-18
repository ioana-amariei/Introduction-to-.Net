using System.Collections.Generic;
using System.Linq;

namespace Books
{
    public interface IBookRepository
    {
        IEnumerable<Book> RetrieveAllBooks();
        IEnumerable<Book> RetrieveAllOrderByYearDescending();
        IEnumerable<Book> RetrieveAllOrderByYearAscending();
        IEnumerable<Book> RetrieveAllOrderByPriceAscending();
        IEnumerable<Book> RetrieveAllOrderByPriceDescending();
        IEnumerable<IGrouping<Genres, Book>> RetrieveAllBooksGroupedByGenre();       
    }
}
