using NUnit.Framework;
using System;
using FluentAssertions;

namespace Company.Data.Test
{
    [TestFixture]
    public class EmployeeTest
    {

        private static Employee[] InactiveEmployees = {
            new Architect(1, "Ioana", "Amariei", DateTime.Now.AddYears(1), DateTime.Now.AddYears(2), 12000) ,
            new Manager(1, "Claudia", "Donea", DateTime.Now.AddYears(1), DateTime.Now.AddYears(2), 9000) 
        };

        private static Employee[] ActiveEmployees = {
            new Architect(1, "Ioana", "Amariei", DateTime.Now.AddDays(-1), DateTime.Now.AddYears(2), 12000) ,
            new Manager(1, "Claudia", "Donea", DateTime.Now.AddYears(-1), DateTime.Now.AddYears(2), 9000)
        };

        [Test, TestCaseSource("InactiveEmployees")]
        public void Given_EmployeeWithHigherDateInTheFuture_Then_IsActiveReturnsFalse(Employee employee)
        {
            employee.IsActive().Should().BeFalse();
        }

        [Test, TestCaseSource("ActiveEmployees")]
        public void Given_ActiveEmployee_Then_IsActiveReturnsTrue(Employee employee)
        {
            employee.IsActive().Should().BeTrue();
        }

        [Test, TestCaseSource("InactiveEmployees")]
        public void Given_EmployeeFirstAndLastName_Then_GetFullNameReturnsName(Employee employee)
        {
            string actual = employee.FirstName + " " + employee.LastName;
            string expected = employee.GetFullName();

            actual.Should().BeEquivalentTo(expected);
        }
    }

}
