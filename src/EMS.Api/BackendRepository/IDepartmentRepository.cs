using EMS.Core;

namespace EMS.Api.BackendRepository;

public interface IDepartmentRepository
{
    Task<IEnumerable<rDepartment>> GetDepartments();
    Task<rDepartment> GetDepartment(int departmentId);
    Task AddDepartment(eDepartment department);
    Task DeleteDepartment(int departmentId);
    Task UpdateDepartment(eDepartment department);
}
