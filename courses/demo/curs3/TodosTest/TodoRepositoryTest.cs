using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todos;

namespace TodosTest
{
    [TestClass]
    public class TodoRepositoryTest
    {
        private TodoRepository _todoRepository;

        [TestInitialize]
        public void InitializeRepository()
        {
            //Arrange
            _todoRepository = new TodoRepository(new List<Todo>
            {
                new Todo
                {
                    Description = "Go to .Net courses",
                    Id = new Guid("05709271-7FD9-4BA3-8412-19F98E72A6F4"),
                    StartDate = DateTime.Now.AddDays(-3),
                    NumberOfDays = 6
                },
                new Todo
                {
                    Description = "Learn Python 3",
                    Id = new Guid("85014099-45D9-44FB-9C64-18634B4BE196"),
                    StartDate = DateTime.Now.AddDays(-2),
                    NumberOfDays = 1
                },
                new Todo
                {
                    Description = "Go to special ML seminary",
                    Id = new Guid("A049033E-1514-44E8-9F68-401BB8B7AC11"),
                    StartDate = DateTime.Now.AddDays(-6),
                    NumberOfDays = 3
                }
            });
        }

        [TestCleanup]
        public void CleanRepository()
        {
            _todoRepository = null;
        }

        [TestMethod]
        public void Given_RepositoryWithActiveTodoList_Then_RetriveActiveTodosReturnsTodoList()
        {
            //Act
            var retriveActiveTodos = _todoRepository.RetriveActiveTodos();

            //Assert
            Assert.IsTrue(retriveActiveTodos.Count() == 1);
        }

        [TestMethod]
        public void Given_RepositoryWithInactiveTodoList_Then_RetriveActiveTodosReturnsInactiveTodoList()
        {
            //Act
            var retriveInactiveTodos = _todoRepository.RetriveAllOrderByStartDateAndInactiveAscending();

            //Assert
            Assert.IsTrue(retriveInactiveTodos.Count() == 2);
        }


        //TODO: correct assert
        [TestMethod]
        public void Given_RepositoryWithInactiveTodoList_Then_RetriveInactiveTodosReturnsOrderedByStartDateInactiveTodoList()
        {
            //Act
            IEnumerable<Todo> actual = _todoRepository.RetriveAllOrderByStartDateAndInactiveAscending();
            var expected = _todoRepository.RetriveInactiveTodos().OrderBy(t => t.StartDate);
            
            //Assert
            Assert.IsTrue(actual.Equals(expected));
        }
    }
}