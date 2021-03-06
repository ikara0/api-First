using BilgeAdam.Common.Dtos;
using BilgeAdam.Common.Dtos.Supplier;
using BilgeAdam.Data.Context;
using BilgeAdam.Data.Entities;
using BilgeAdam.Services.Abstractions;

namespace BilgeAdam.Services.Concretes
{
    internal class SupplierService : ISupplierService
    {
        private readonly NorthwindDbContext dbContext;

        public SupplierService(NorthwindDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool AddNewSupplier(SupplierAddDto dto)
        {
            var @new = new Supplier
            {
                Address = dto.Address,
                CompanyName = dto.CompanyName,
                ContactName = dto.ContactName,
                Phone = dto.Phone,
                Fax = dto.Fax,
                City = dto.City,
                Region = dto.Region,
                PostalCode = dto.PostalCode,
                Country = dto.Country,
                ContactTitle = dto.ContactTitle,
            };
            dbContext.Add(@new);
            return dbContext.SaveChanges() > 0;
        }

        public bool DeleteSupplierById(int id)
        {
            var result = dbContext.Suppliers.Where(x => x.SupplierID == id).FirstOrDefault();
            if (result is null)
            {
                return false;
            }
            dbContext.Remove(result);
            return dbContext.SaveChanges() > 0;
        }

        public PagedList<List<SupplierListDto>> GetPagedSuppliers(int count, int page)
        {
            var data = dbContext.Suppliers.Skip((page - 1) * count).Take(count).Select(x => new SupplierListDto
            {
                SupplierID = x.SupplierID,
                Address = $"{x.Address}, {x.Region}, {x.City}/{x.Country.ToUpper()}",
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                Title = x.ContactTitle,
                Fax = x.Fax,
                Phone = x.Phone,
            }).ToList();

            var totalCount = dbContext.Suppliers.Skip(page * count).Count();

            return new PagedList<List<SupplierListDto>>() { Data = data, TotalCount = totalCount };
        }

        public SupplierDto GetSupplierById(int id)
        {
            return dbContext.Suppliers.Where(x => x.SupplierID == id).Select(x => new SupplierDto
            {
                Country = x.Country,
                City = x.City,
                Address = x.Address,
                CompanyName = x.CompanyName,
                ContactName = x.ContactName,
                Fax = x.Fax,
                Phone = x.Phone,
                Region = x.Region,
            }).SingleOrDefault();
        }

        public bool UpdateSupplier(SupplierUpdateDto dto)
        {
            var data = dbContext.Suppliers.Where(s => s.SupplierID == dto.Id).FirstOrDefault();
            if (data is null)
            {
                return false;
            }
            data.CompanyName = dto.CompanyName;
            data.ContactName = dto.ContactName;
            data.Address= dto.Address;
            data.City = dto.City;
            data.Address = dto.Address;
            data.Country = dto.Country;
            data.Phone=dto.Phone;
            dbContext.Update(data);

            return dbContext.SaveChanges() > 0;
        }
    }
}