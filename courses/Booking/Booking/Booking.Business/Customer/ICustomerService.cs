using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Business
{
    public interface ICustomerService
    {
        Task<List<CustomerDetailsModel>> GetAll();

        Task<CustomerDetailsModel> FindById(Guid id);

        Task<Guid> CreateNew(CreatingCustomerModel newCustomer);
    }
}
