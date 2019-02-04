using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain;
using Microsoft.EntityFrameworkCore;

namespace Booking.Business
{
    public sealed class CustomerService : ICustomerService
    {
        private readonly IRepository repository;

        public CustomerService(IRepository repository) => this.repository = repository;

        public Task<List<CustomerDetailsModel>> GetAll() => GetAllCustomersDetails().ToListAsync();

        public Task<CustomerDetailsModel> FindById(Guid id) => GetAllCustomersDetails().SingleOrDefaultAsync(c => c.Id == id);

        public async Task<Guid> CreateNew(CreatingCustomerModel newCustomer)
        {
            var customer = Customer.Create(
                firstName: newCustomer.FirstName, 
                lastName: newCustomer.LastName, 
                email: newCustomer.Email);

            await this.repository.AddNewAsync(customer);
            await this.repository.SaveAsync();

            return customer.Id;
        }

        private IQueryable<CustomerDetailsModel> GetAllCustomersDetails() => this.repository.GetAll<Customer>()
                       .Select(c => new CustomerDetailsModel
                       {
                           Id = c.Id,
                           FirstName = c.FirstName,
                           LastName = c.LastName,
                           Email = c.Email,
                           MoneySpent = c.MoneySpent
                       });
    }
}
