using EMS.Core;

namespace EMS.Api.BackendRepository;

public interface ICompanyRepository
{
    Task<IEnumerable<eDepartment>> GetDepartmentsAsync();
    Task<eDepartment?> GetDepartmentAsync(int departmentId);
    Task AddDepartmentAsync(eDepartment department);
    Task<bool> DeleteDepartmentAsync(int departmentId);
    Task<bool> UpdateDepartmentAsync(eDepartment department);
    Task<bool> DepartmentExists(int departmentId);

    Task<IEnumerable<eEmployee>> GetAllEmployeesAsync();
    Task<IEnumerable<eEmployee>> GetDepartmentEmployeesAsync(int departmentId);
    Task<eEmployee?> GetEmployeeAsync(int departmentId, int employeeId);
    Task AddEmployeeAsync(int departmentId, eEmployee employee);
    Task<bool> DeleteEmployeeAsync(int departmentId, int employeeId);
    Task<bool> UpdateEmployeeAsync(int departmentId, int employeeId, cEmployee employee);
}
