using System;

namespace Company.Data
{
    public class Manager : Employee
    {
        public Manager(long id, string firstName, string lastName, DateTime startDate, DateTime endDate, long salary) : base(id, firstName, lastName, startDate, endDate, salary)
        {

        }
    }
}