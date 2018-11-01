using System;
using System.ComponentModel.DataAnnotations;

namespace Authors
{
    public class Book
    {
        public Guid Id { get; private set; }

        [MaxLength(100), MinLength(50)]
        public string Title { get; private set; }

        public Guid AuthorId { get; private set; }

        public Book(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }

        private Book()
        {
            //EF
        }
    }
}