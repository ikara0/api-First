using BilgeAdam.Common.Dtos;

namespace BilgeAdam.Services.Abstractions
{
    public interface ISupplierService
    {
        PagedList<List<SupplierListDto>> GetPagedSuppliers(int count, int page);
        SupplierDto GetSupplierById(int id);
        bool AddNewSupplier(SupplierAddDto dto);
        bool DeleteSupplierById(int id);
    }
}