using System;
using System.Collections.Generic;
using System.Linq;
using Books;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//    IEnumerable<Book> RetrieveAllOrderByYearDescending();
//    IEnumerable<Book> RetrieveAllOrderByYearAscending();
//    IEnumerable<Book> RetrieveAllOrderByPriceAscending();
//    IEnumerable<Book> RetrieveAllOrderByPriceDescending();
//    IEnumerable<IGrouping<Genres, Book>> RetrieveAllBooksGroupedByGenre();
namespace BooksTest
{
    [TestClass]
    public class BookRepositoryTest
    {
        private BookRepository _bookRepository;

        [TestInitialize]
        public void InitializeRepository()
        {
            _bookRepository = new BookRepository(new List<Book>
            {
                new Book
                {
                    Genres = Genres.NonFiction,
                    Id = new Guid("807E33E2-C380-4B58-8216-91B8BD8F5545"),
                    Price = 50.6,
                    Title = "Clean Code",
                    Year = DateTime.Now.AddYears(-10)
                },
                new Book
                {
                    Genres = Genres.NonFiction,
                    Id = new Guid("CFC5FF48-3617-4FAA-8FB8-9605B7E15172"),
                    Price = 25.7,
                    Title = "Homo deus",
                    Year = DateTime.Now.AddYears(-3)
                },
                new Book
                {
                    Genres = Genres.NonFiction,
                    Id = new Guid("9C3EBA47-7445-4B36-99E6-19B6EFD1C92C"),
                    Price = 24.0,
                    Title = "Sapiens",
                    Year = DateTime.Now.AddYears(-5)
                },
                new Book
                {
                    Genres = Genres.Fiction,
                    Id = new Guid("9F0468CF-5E7D-404D-8AB1-E55AFB947DAD"),
                    Price = 15.0,
                    Title = "1984",
                    Year = DateTime.Now.AddYears(-6)
                }
            });
        }

        [TestCleanup]
        public void CleanRepository()
        {
            _bookRepository = null;
        }

        [TestMethod]
        public void Given_NonEmptyRepository_Then_RetrieveAllBooksReturnsAllBooks()
        {
            var books = _bookRepository.RetrieveAllBooks();
            Assert.IsTrue(books.Count() == 4);
        }
    }
}
