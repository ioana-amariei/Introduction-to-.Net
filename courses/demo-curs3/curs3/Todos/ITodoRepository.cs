using System.Collections.Generic;

namespace Todos
{
    public interface ITodoRepository
    {
        IEnumerable<Todo> RetriveActiveTodos();
        IEnumerable<Todo> RetriveInactiveTodos();
        IEnumerable<Todo> RetriveAllOrderByStartDateDescending();
        IEnumerable<Todo> RetriveAllOrderByStartDateAscending();
        IEnumerable<Todo> RetriveAllOrderByStartDateAndInactiveAscending();
    }
}
