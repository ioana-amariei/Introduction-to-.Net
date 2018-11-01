using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Authors
{
    public sealed class Author
    {
        public Guid Id { get; private set; }

        [MaxLength(100), MinLength(50)]
        public string FirstName { get; private set; }

        [MaxLength(150)]
        public string LastName { get; private set; }

        public ICollection<Book> Books { get; set; }

        public Author(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Books = new HashSet<Book>();
        }

        private Author()
        {
            // EF
        }
    }
}