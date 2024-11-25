using CrudAPI.Contracts;
using CrudAPI.Models;

namespace CrudAPI.Interface
{
    public interface IEmployeeServices
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(Guid id);
        Task CreateEmployeeAsync(CreateEmployeeRequest request);
        Task UpdateEmployeeAsync(Guid id, UpdateEmployeeRequest request);
        Task DeleteEmployeeAsync(Guid id);
    }
}
