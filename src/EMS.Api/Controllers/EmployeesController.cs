using System.Reflection.Emit;
using EMS.Api.BackendRepository;
using EMS.Api.Mapping;
using EMS.Core;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers;

[ApiController]
[Route("/api/departments/{departmentId}/employees")]
public class EmployeesController : ControllerBase
{
    public ICompanyRepository _repo;
    public EmployeesController(ICompanyRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("/api/employees")]
    public async Task<ActionResult<rEmployees>> GetAllEmployees()
    {
        var entities = await _repo.GetAllEmployeesAsync();
        return Ok(entities.MapEntitiesToEmployees());
    }

    [HttpGet]
    public async Task<ActionResult<rEmployees>> GetDepartmentEmployees(int departmentId)
    {
        var employees = await _repo.GetDepartmentEmployeesAsync(departmentId);

        return employees.MapEntitiesToEmployees();
    }

    [HttpGet("{employeeId}", Name="GetEmployee")]
    public async Task<ActionResult<rEmployee>> GetEmployee(int departmentId, int employeeId)
    {
        var found = await _repo.GetEmployeeAsync(departmentId, employeeId);

        if (found == null) return NotFound();

        return found.MapEntityToEmployee();
    }

    [HttpPost]
    public async Task<ActionResult<eEmployee>> AddEmployee(
        int departmentId, cEmployee employee)
    {
        if (departmentId != employee.DepartmentId) return NotFound();

        eEmployee entity = employee.MapCreateToEntity();
        await _repo.AddEmployeeAsync(departmentId, entity);

        return CreatedAtRoute(
            "GetEmployee",
            new
            {
                departmentId = departmentId,
                employeeId = entity.Id
            },
            entity);
    }

    [HttpPut("{employeeId}")]
    public async Task<IActionResult> UpdateEmployee(
        int departmentId, int employeeId, cEmployee employee)
    {
        var entity = employee.MapCreateToEntity();
        var updated = await _repo.UpdateEmployeeAsync(departmentId, employeeId, entity); 
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{employeeId}")]
    public async Task<IActionResult> DeleteEmployee(int employeeId, int departmentId)
    {
        var deleted = await _repo.DeleteEmployeeAsync(departmentId, employeeId);
        if (!deleted) return NotFound();

        return NoContent();

    }
}