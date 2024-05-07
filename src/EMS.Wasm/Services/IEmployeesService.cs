using EMS.Core;

namespace EMS.Web.Services;

public interface IEmployeesService
{
   Task<rEmployees> GetAllEmployees();
   Task<rEmployees> GetDepartmentEmployees(int departmentId);
   Task<rEmployee> GetEmployee(int departmentId, int employeeId);
   Task<rEmployees> Search(string search);
   Task AddEmployee(int departmentId, cEmployee employee);
   Task DeleteEmployee(int departmentId, int employeeId);
   Task UpdateEmployee(int departmentId, int employeeId, cEmployee employee);
}