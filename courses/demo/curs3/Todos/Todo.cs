using System;

namespace Todos
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfDays { get; set; }
    }
}
