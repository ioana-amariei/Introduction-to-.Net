using System;
using System.Linq;
using Authors;

namespace Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbContext = new ApplicationContext();
            var unitOfWork = new UnitOfWork(dbContext);

            // Create
            var firstAuthor = new Author("Fowler", "Martin");
            var secondAuthor = new Author("Martin", "Robert");
            unitOfWork.AuthorRepository.Create(firstAuthor);
            unitOfWork.AuthorRepository.Create(secondAuthor);

            var firstBook = new Book("Refactoring");
            var secondBook = new Book("Clean code");
            unitOfWork.BookRepository.Create(firstBook);
            unitOfWork.BookRepository.Create(secondBook);

            unitOfWork.Commit(); // Save changes to database

            var book = unitOfWork.BookRepository.Entities.First(b => b.Title == "Clean Code");
            unitOfWork.BookRepository.RemoveById(book.Id);
            unitOfWork.Commit(); // Save changes to database

            // lazy loading
            var query = dbContext.Books;
            foreach (var item in query)
            {
                Console.WriteLine(item.Title);
            }

            // eager loading
            var books = dbContext.Books.ToList();

            // explicit loading
            var author = dbContext.Authors.Single(a => a.FirstName == "Martin");
            dbContext.Entry(author).Collection(b => b.Books).Load();
        }
    }
}