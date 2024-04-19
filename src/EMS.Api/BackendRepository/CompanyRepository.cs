using EMS.Api.Data;
using EMS.Core;
using Microsoft.EntityFrameworkCore;

namespace EMS.Api.BackendRepository;

public class CompanyRepository : ICompanyRepository
{
    private readonly CompanyDbContext _context;

    public CompanyRepository(CompanyDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<eDepartment>> GetDepartmentsAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<eDepartment?> GetDepartmentAsync(int departmentId)
    {
        return await _context.Departments.SingleOrDefaultAsync(d => d.Id == departmentId);
    }

    public async Task AddDepartmentAsync(eDepartment department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDepartmentAsync(int departmentId)
    {
        var department = GetDepartmentAsync(departmentId);
        if (department == null) return;
        _context.Remove(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDepartmentAsync(eDepartment department)
    {
        var match = await GetDepartmentAsync(department.Id);
        if (match == null) return;
        match.DepartmentName = department.DepartmentName;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DepartmentExists(int departmentId)
    {
        var match = await GetDepartmentAsync(departmentId);
        if (match == null) return false;
        return true;
    }

    public async Task<IEnumerable<eEmployee>> GetAllEmployeesAsync()
    {
        return await _context.Employees.ToListAsync();
    }

    public async Task<IEnumerable<eEmployee>> GetDepartmentEmployeesAsync(int departmentId)
    {
        return await _context.Employees.Where(e => e.DepartmentId == departmentId).ToListAsync();
    }

    public async Task<eEmployee?> GetEmployeeAsync(int departmentId, int employeeId)
    {
        return await _context.Employees.SingleOrDefaultAsync(e => e.DepartmentId == departmentId);
    }

    public Task AddEmployeeAsync(int departmentId, eEmployee employee)
    {
        var department = 
    }

    public Task DeleteEmployeeAsync(int employeeId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployeeAsync(eEmployee employee)
    {
        throw new NotImplementedException();
    }
}