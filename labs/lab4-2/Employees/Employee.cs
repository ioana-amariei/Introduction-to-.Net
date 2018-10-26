using System;
using System.ComponentModel.DataAnnotations;

namespace Employees
{
    public class Employee
    {
        public Guid Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; private set; }

        [Required]
        [StringLength(70)]
        public string LastName { get; private set; }

        [Required]
        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        public decimal? Salary { get; private set; }

        private Employee()
        {
            // Entity Framework
        }

        public Employee(string firstName, string lastName, DateTime startDate, DateTime? endDate, decimal? salary)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
            Salary = salary;
        }

        public bool IsActive()
        {
            var now = DateTime.Now;
            return StartDate < now && EndDate > now;
        }
        
        public void Update(Employee employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            StartDate = employee.StartDate;
            EndDate = employee.EndDate;
            Salary = employee.Salary;
        }
    }
}