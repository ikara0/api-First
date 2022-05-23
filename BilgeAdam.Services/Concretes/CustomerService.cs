using BilgeAdam.Common.Dtos;
using BilgeAdam.Common.Dtos.Customer;
using BilgeAdam.Data.Context;
using BilgeAdam.Data.Entities;
using BilgeAdam.Services.Abstractions;

namespace BilgeAdam.Services.Concretes
{
    internal class CustomerService : ICustomerService
    {
        private readonly NorthwindDbContext dbContext;

        public CustomerService(NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool CreateNewCustomer(CustomerAddDto dto)
        {
            var conflict = dbContext.Customers.Where(c => c.CustomerID.ToLower() == dto.CustomerId.ToLower()).SingleOrDefault();
            if (conflict != null)
            {
                return false;
            }
            var newCustomer = new Customer
            {
                CustomerID = dto.CustomerId.ToUpper(),
                CompanyName = dto.CompanyName,
                ContactName = dto.ContactName,
                ContactTitle = dto.ContactTitle,
                Region = dto.Region,
                Country = dto.Country.ToUpper(),
                Phone=dto.Phone,
                Fax=dto.Fax,
                Address=dto.Address,
                City=dto.City.ToUpper(),
                PostalCode=dto.PostalCode,
            };
            dbContext.Add(newCustomer);
            return dbContext.SaveChanges() > 0;
        }

        public CustomerDto GetCustomerById(string id)
        {
            var result = dbContext.Customers.Where(c => c.CustomerID.ToLower() == id.ToLower()).Select(c => new CustomerDto
            {
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Address = c.Address,
                City = c.City,
                Region = c.Region,
                Country = c.Country,
                Phone = c.Phone,
                Fax = c.Fax,
            }).SingleOrDefault();

            return result;  
        }

        public PagedList<List<CustomerListDto>> GetPagedCustomers(int count, int page)
        {
            var data = dbContext.Customers.Skip((page - 1) * count).Take(count).Select(c => new CustomerListDto
            {
                Id = c.CustomerID,
                CompanyName = c.CompanyName,
                ContactName = c.ContactName,
                ContactTitle = c.ContactTitle,
                Address = $"{c.Address},{c.Region},{c.City}/{c.Country.ToUpper()}",
                Phone = c.Phone,
                Fax = c.Fax,
            }).ToList();

            var totalCount = dbContext.Customers.Skip(page * count).Count();
            return new PagedList<List<CustomerListDto>>() { Data = data, TotalCount = totalCount };
        }

        public bool RemoveCustomerById(string id)
        {
            var data = dbContext.Customers.SingleOrDefault(c => c.CustomerID == id);
            if(data is null)
            {
                return false;
            }
            dbContext.Customers.Remove(data);
            return dbContext.SaveChanges() > 0;
        }

        public bool UpdateCustomer(CustomerUpdateDto dto)
        {
            var data = dbContext.Customers.Where(c => c.CustomerID == dto.Id).FirstOrDefault();
            if(data == null)
            {
                return false;
            }
            data.CompanyName= dto.CompanyName;
            data.ContactName= dto.ContactName;
            data.ContactTitle= dto.ContactTitle;
            data.Address= dto.Address;
            data.City= dto.City;
            data.Region= dto.Region;
            data.PostalCode= dto.PostalCode;
            data.Country= dto.Country;
            data.Phone= dto.Phone;
            data.Fax= dto.Fax;
            dbContext.Update(data);
            return dbContext.SaveChanges() > 0;

        }
    }
}