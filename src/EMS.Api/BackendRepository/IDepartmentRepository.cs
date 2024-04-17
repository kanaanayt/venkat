using EMS.Core;

namespace EMS.Api.BackendRepository;

public interface IDepartmentRepository
{
    Task<IEnumerable<rDepartment>> GetDepartmentsAsync();
    Task<rDepartment> GetDepartmentAsync(int departmentId);
    Task AddDepartmentAsync(eDepartment department);
    Task DeleteDepartmentAsync(int departmentId);
    Task UpdateDepartmentAsync(eDepartment department);
}
