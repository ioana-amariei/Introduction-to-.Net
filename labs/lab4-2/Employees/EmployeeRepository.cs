using System;
using System.Linq;

namespace Employees
{
    public class EmployeeRepository:IRepository<Employee>
    {
        public ApplicationContext ApplicationContext;

        public EmployeeRepository()
        {
            ApplicationContext = new ApplicationContext();
        }

        public void Create(Employee employee)
        {
            ApplicationContext.Add(employee);
            ApplicationContext.SaveChanges();
        }

        public void Update(Employee employee)
        {
            var updatedEmployee = ApplicationContext.Employees.Find(employee.Id);
            updatedEmployee.Update(employee);
            ApplicationContext.Update(updatedEmployee);
            ApplicationContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            ApplicationContext.Remove(employee);
            ApplicationContext.SaveChanges();
        }

        public Employee GetById(Guid id)
        {
            return ApplicationContext.Employees.Find(id);
        }

        public IQueryable<Employee> GetAll()
        {
            return ApplicationContext.Employees;
        }

        public IQueryable<Employee> GetEmployeesBySalary(decimal salary)
        {
            return ApplicationContext.Employees.Where(e => e.Salary == salary);
        }
    }
}
