using System;

namespace Company.Data
{
    public class Architect : Employee
    {
        public Architect(long id, string firstName, string lastName, DateTime startDate, DateTime endDate, long salary) : base(id, firstName, lastName, startDate, endDate, salary)
        {
        }
    }
}
