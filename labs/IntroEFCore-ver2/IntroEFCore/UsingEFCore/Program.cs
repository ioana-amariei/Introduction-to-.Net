using System;
using IntroEFCore;

namespace UsingEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            // manipulating Todo's
            var repository = new TodoRepository();

            var entity = new Todo
            {
                Id = Guid.NewGuid(),
                Description = "Testing manipulations",
                IsCompleted = false
            };

            repository.Add(todo: entity);
            entity.Description = "Test";
            repository.Edit(entity);
        }
    }
}
