using EMS.Core;

namespace EMS.Api.BackendRepository;

public interface ICompanyRepository
{
    Task<IEnumerable<eDepartment>> GetDepartmentsAsync();
    Task<eDepartment?> GetDepartmentAsync(int departmentId);
    Task AddDepartmentAsync(eDepartment department);
    Task DeleteDepartmentAsync(int departmentId);
    Task UpdateDepartmentAsync(eDepartment department);
    Task<bool> DepartmentExists(int departmentId);

    Task<IEnumerable<eEmployee>> GetAllEmployeesAsync();
    Task<IEnumerable<eEmployee>> GetDepartmentEmployeesAsync(int departmentId);
    Task<eEmployee?> GetEmployeeAsync(int departmentId, int employeeId);
    Task AddEmployeeAsync(int departmentId, eEmployee employee);
    Task DeleteEmployeeAsync(int departmentId, int employeeId);
    Task UpdateEmployeeAsync(int departmentId, eEmployee employee);
}
