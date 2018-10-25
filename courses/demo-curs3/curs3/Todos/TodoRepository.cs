using System;
using System.Collections.Generic;
using System.Linq;

namespace Todos
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IEnumerable<Todo> _todos;

        public TodoRepository(IEnumerable<Todo> todos)
        {
            _todos = todos;
        }
        
        public IEnumerable<Todo> RetriveActiveTodos()
        {
            return (from todo in _todos
                         where todo.StartDate.AddDays(todo.NumberOfDays) > DateTime.Now
                         select todo);
        }

        public IEnumerable<Todo> RetriveAllOrderByStartDateAndInactiveAscending()
        {
            return RetriveInactiveTodos().OrderBy(todo => todo.StartDate);
        }

        public IEnumerable<Todo> RetriveAllOrderByStartDateAscending()
        {
            return _todos.OrderBy(todo => todo.StartDate);
        }

        public IEnumerable<Todo> RetriveAllOrderByStartDateDescending()
        {
            return _todos.OrderByDescending(todo => todo.StartDate);
        }

        public IEnumerable<Todo> RetriveInactiveTodos()
        {
            return _todos.Where(todo => todo.StartDate.AddDays(todo.NumberOfDays) < DateTime.Now); 
        }
    }
}
