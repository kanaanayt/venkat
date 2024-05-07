using EMS.Core;

namespace EMS.Web.Services;

public interface IEmployeesService
{
   Task<IEnumerable<rEmployees>> GetAllEmployees();
   Task<rEmployees> GetDepartmentDemployees(int id);
   Task<rEmployee> GetEmployee(int departmentId, int employeeId);
   Task<rEmployees> Search(string search);
   Task AddEmployee(int departmentId, cEmployee employee);
   Task UpdateEmployee(int departmentId, int employeeId);
   Task DeleteEmployee(int departmentId, int employeeId, cEmployee employee);
}