using BilgeAdam.Common.Dtos;
using BilgeAdam.Common.Dtos.Customer;

namespace BilgeAdam.Services.Abstractions
{
    public interface ICustomerService
    {
        PagedList<List<CustomerListDto>> GetPagedCustomers(int count, int page);
        CustomerDto GetCustomerById(string id);
        bool CreateNewCustomer(CustomerAddDto dto);
        bool RemoveCustomerById(string id);
        bool UpdateCustomer(CustomerUpdateDto dto);
    }
}