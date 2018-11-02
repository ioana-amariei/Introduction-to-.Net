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
            var thirdAuthor = new Author("Evans", "Eric");

            unitOfWork.AuthorRepository.Create(firstAuthor);
            unitOfWork.AuthorRepository.Create(secondAuthor);
            unitOfWork.AuthorRepository.Create(thirdAuthor);

            unitOfWork.Commit(); // Save changes to database

            var firstBook = new Book("Refactoring");
            firstBook.AttachAuthor(firstAuthor.Id);
            
            var secondBook = new Book("Clean code");
            secondBook.AttachAuthor(secondAuthor.Id);

            var thirdBook = new Book("Domain Driven Design");
            thirdBook.AttachAuthor(thirdAuthor.Id);

            unitOfWork.BookRepository.Create(firstBook);
            unitOfWork.BookRepository.Create(secondBook);
            unitOfWork.BookRepository.Create(thirdBook);

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
            var authors = dbContext.Authors.ToList();
            foreach (var item in authors)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

            // explicit loading
            var author = dbContext.Authors.FirstOrDefault(a => a.FirstName == "Martin");
            dbContext.Entry(author).Collection(b => b.Books).Load();


            // Remove
//            var firstBook = unitOfWork.BookRepository.Entities.First(b => b.Title == "Refactoring");
//            var firstAuthor = unitOfWork.AuthorRepository.Entities.First(a => a.FirstName == "Fowler");
            unitOfWork.BookRepository.RemoveById(firstBook.Id);
            unitOfWork.AuthorRepository.RemoveById(firstAuthor.Id);

            unitOfWork.Commit(); // Save changes to database

            Console.WriteLine("Book and author removed");

            Console.ReadKey();
        }
    }
}