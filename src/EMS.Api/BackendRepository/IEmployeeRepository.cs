using EMS.Core;

namespace EMS.Api.BackendRepository;

public interface IEmployeeRepository
{
    Task<IEnumerable<rEmployee>> GetAllEmployeesAsync();
    Task<IEnumerable<rEmployee>> GetDepartmentEmployeesAsync(int departmentId);
    Task<eEmployee> GetEmployeeAsync(int employeeId);
    Task AddEmployeeAsync(int departmentId, eEmployee employee);
    Task DeleteEmployeeAsync(int employeeId);
    Task UpdateEmployeeAsync(eEmployee employee);
}
