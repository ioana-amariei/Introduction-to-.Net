using System;
using System.ComponentModel;

namespace Books
{
    [Flags]
    public enum Genres
    {
        [Description("Fiction")] Fiction,
        [Description("NonFiction")] NonFiction
    }

    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public Genres Genres = Genres.Fiction | Genres.NonFiction;
    }
}