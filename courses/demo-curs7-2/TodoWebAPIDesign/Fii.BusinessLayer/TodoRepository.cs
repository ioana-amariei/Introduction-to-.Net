using System;
using System.Collections.Generic;
using Fii.DataLayer;
using  System.Linq;

namespace Fii.BusinessLayer
{
    public interface ITodoRepository
    {
        void Create(Todo todo);
        Todo GetById(Guid id);
        IReadOnlyList<Todo> GetAll();
    }

    public class TodoRepository : ITodoRepository
    {
        private readonly TodoContext context;

        public TodoRepository(TodoContext context)
        {
            this.context = context;
        }

        public void Create(Todo todo)
        {
            if (todo != null)
            {
                this.context.Todos.Add(todo);
                this.context.SaveChanges();
            }
        }

        public Todo GetById(Guid id)
        {
            return this.context.Todos.FirstOrDefault(t => t.Id == id);
        }

        public IReadOnlyList<Todo> GetAll()
        {
            return this.context.Todos.ToList();
        }
    }
}