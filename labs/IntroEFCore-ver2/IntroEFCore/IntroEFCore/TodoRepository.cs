using System;
using System.Linq;

namespace IntroEFCore
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext _context;

        public TodoRepository()
        {
            this._context = new TodoContext();
        }

        public void Add(Todo todo)
        {
            _context.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void Edit(Todo todo)
        {
            var existingTodo = this._context.Todos.First(t => t.Id == todo.Id);
            existingTodo.Description = todo.Description;
            existingTodo.IsCompleted = todo.IsCompleted;
            _context.SaveChanges();
        }

        public Todo GetById(Guid id)
        {
            return this._context.Todos.First(t => t.Id == id);
        }


    }
}
