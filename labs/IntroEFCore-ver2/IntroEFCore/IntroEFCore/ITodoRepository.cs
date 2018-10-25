using System;

namespace IntroEFCore
{
    public interface ITodoRepository
    {
        void Add(Todo todo);
        void Edit(Todo todo);
        Todo GetById(Guid id);
    }
}