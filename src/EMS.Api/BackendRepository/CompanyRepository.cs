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
        return await _context.Departments
                             .Include(d => d.Employees)
                             .SingleOrDefaultAsync(d => d.Id == departmentId);
    }

    public async Task AddDepartmentAsync(eDepartment department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteDepartmentAsync(int departmentId)
    {
        var department = await GetDepartmentAsync(departmentId);
        if (department == null) return false;
        _context.Remove(department);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateDepartmentAsync(eDepartment department)
    {
        var match = await GetDepartmentAsync(department.Id);
        if (match == null) return false;
        match.DepartmentName = department.DepartmentName;
        await _context.SaveChangesAsync();
        return true;
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
        if (await DepartmentExists(departmentId))
        {
            return await _context.Employees.Where(e => e.DepartmentId == departmentId).ToListAsync();
        }
        
        return Enumerable.Empty<eEmployee>();
    }

    public async Task<eEmployee?> GetEmployeeAsync(int departmentId, int employeeId)
    {
        if (await DepartmentExists(departmentId))
        {
            return await _context.Employees.SingleOrDefaultAsync(e =>
                e.DepartmentId == departmentId && e.Id == employeeId);
        }

        return null;
    }

    public async Task<IEnumerable<eEmployee>> Search(string search)
    {
         IQueryable<eEmployee> query = _context.Employees;
         query = query.Where(e => e.FirstName.Contains(search)
         || e.LastName.Contains(search));
         return await query.ToListAsync();
    }

    public async Task AddEmployeeAsync(int departmentId, eEmployee employee)
    {
        if (await DepartmentExists(departmentId))
        {
            var department = await GetDepartmentAsync(departmentId);
            if (department == null) return;
            department.Employees.Add(employee);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> DeleteEmployeeAsync(int departmentId, int employeeId)
    {
        if (await DepartmentExists(departmentId))
        {
            var department = await GetDepartmentAsync(departmentId);
            if (department == null) return false;

            var employee = await GetEmployeeAsync(departmentId, employeeId);
            if (employee == null) return false;
            
            department.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> UpdateEmployeeAsync(
        int departmentId, int employeeId, cEmployee employee)
    {
        if (await DepartmentExists(departmentId))
        {
            var match = await GetEmployeeAsync(departmentId, employeeId);

            if (match == null) return false;

            match.FirstName = employee.FirstName;
            match.LastName = employee.LastName;
            match.PhotoPath = employee.PhotoPath;
            match.JoinDate = employee.JoinDate;
            match.Email = employee.Email;
            match.Gender = employee.Gender;

            await _context.SaveChangesAsync();
        }

        return true;
    }
}