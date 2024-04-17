using EMS.Core;

namespace EMS.Api.BackendRepository;

public interface IEmployeeRepository
{
    Task<IEnumerable<rEmployee>> GetAllEmployees();
    Task<IEnumerable<rEmployee>> GetDepartmentEmployees(int departmentId);
    Task<eEmployee> GetEmployee(int employeeId);
    Task AddEmployee(int departmentId, eEmployee employee);
    Task DeleteEmployee(int employeeId);
    Task UpdateEmployee(eEmployee employee);
}
