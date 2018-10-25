using System;
using System.ComponentModel.DataAnnotations;

namespace Employees
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(70)]
        public string LastName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public decimal? Salary { get; set; }

        public Employee(string firstName, string lastName, DateTime startDate, DateTime endDate, long salary)
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
    }
}
