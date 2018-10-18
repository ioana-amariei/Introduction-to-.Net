using System;

namespace Company.Data
{ 
    public abstract class Employee
    {
        public long Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public long Salary { get; }

        public Employee(long id, string firstName, string lastName, DateTime startDate, DateTime endDate, long salary)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            StartDate = startDate;
            EndDate = endDate;
            Salary = salary;
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }

        public bool IsActive()
        {
            DateTime now = DateTime.Now;
            return StartDate < now && EndDate > now;
        }

        public virtual string  Salutation()
        {
            return "Hello " + this.GetType().Name + " " + GetFullName();
        }
    }
}
