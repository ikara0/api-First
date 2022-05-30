using BilgeAdam.Common.Dtos;
using BilgeAdam.Common.Dtos.Supplier;

namespace BilgeAdam.Services.Abstractions
{
    public interface ISupplierService
    {
        PagedList<List<SupplierListDto>> GetPagedSuppliers(int count, int page);
        SupplierDto GetSupplierById(int id);
        bool AddNewSupplier(SupplierAddDto dto);
        bool DeleteSupplierById(int id);
        bool UpdateSupplier(SupplierUpdateDto dto);
    }
}