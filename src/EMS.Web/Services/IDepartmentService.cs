using EMS.Core;

namespace EMS.Web.Services;

public interface IDepartmentService
{
    Task<rDepartments> GetDepartments();
    Task<rDepartment> GetDepartment(int id);
    Task AddDepartment(cDepartment department);
    Task UpdateDepartment(cDepartment department, int id);
    Task DeleteDepartment(int id);
}