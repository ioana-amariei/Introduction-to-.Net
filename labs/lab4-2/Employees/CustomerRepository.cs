using System;
using System.Linq;

namespace Employees
{
    public class CustomerRepository:IRepository<Customer>
    {
        public ApplicationContext ApplicationContext;

        public CustomerRepository()
        {
            ApplicationContext = new ApplicationContext();
        }

        public void Create(Customer customer)
        {
            ApplicationContext.Add(customer);
            ApplicationContext.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var updatedCustomer = ApplicationContext.Customers.Find(customer.Id);
            updatedCustomer.Email = "updated@gmail.com";
            ApplicationContext.SaveChanges();
        }

        public void Delete(Customer customer)
        {
            ApplicationContext.Remove(customer);
            ApplicationContext.SaveChanges();
        }

        public Customer GetById(Guid id)
        {
            return ApplicationContext.Customers.Find(id);
        }

        public IQueryable<Customer> GetAll()
        {
            return ApplicationContext.Customers;
        }

        public IQueryable<Customer> GetCustomerByEmail(string email)
        {
            return ApplicationContext.Customers.Where(c => c.Email == email);
        }
    }
}
