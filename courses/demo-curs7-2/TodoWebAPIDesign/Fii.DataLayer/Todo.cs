using System;

namespace Fii.DataLayer
{
    public class Todo
    {
        public  Guid Id { get; set; }
        public  string Description { get; set; }
        public  bool IsCompleted { get; set; }
    }
}
