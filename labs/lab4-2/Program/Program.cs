using System;
using Employees;

namespace Program
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var customerRepository = new CustomerRepository();
            var customer = new Customer("Ioana", "Iasi", "0784043489", "ioana.c.birsan@gmail.com");
            customerRepository.Create(customer);

            var employeeRepository = new EmployeeRepository();
            var employee = new Employee("Ioana", "Birsan", DateTime.Now.AddDays(-10), DateTime.Now, 5000);
            employeeRepository.Create(employee);
            
            var updatedEmployee = new Employee(employee.FirstName, "Amariei", employee.StartDate, employee.EndDate, employee.Salary);
            employee.Update(updatedEmployee);
            employeeRepository.Update(employee);
        }
    }
}
