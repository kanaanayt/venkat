using System.Reflection.Emit;
using System.ComponentModel;
using AutoMapper;
using EMS.Api.BackendRepository;
using EMS.Api.Mapping;
using EMS.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EMS.Api.Controllers;

[ApiController]
[Route("/api/departments")]
public class DepartmentsController : ControllerBase
{
    private readonly ICompanyRepository _repo;
    
    public DepartmentsController(ICompanyRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult<rDepartments>> GetDepartments()
    {
        var entities = await _repo.GetDepartmentsAsync();
        if (entities == null) return new rDepartments();
        return Ok(entities.MapEntitiesToDepartments());
    }

    [HttpGet("{id}", Name = "GetDept")]
    public async Task<ActionResult<rDepartment>> GetDepartment(int id)
    {
        var entity = await _repo.GetDepartmentAsync(id);

        if (entity == null) return NotFound();

        return Ok(entity.MapEntityToDepartment());
    }

    [HttpPost]
    public async Task<ActionResult<eDepartment>> AddDepartment(cDepartment department)
    {
        var IsValid = await ValidateDepartment(_repo, department.DepartmentName);
        if (!IsValid) 
        {
            ModelState.AddModelError("DepartmentName", "Duplicate department name");
            var problemDetails = new ValidationProblemDetails(ModelState)
            {
                Status = StatusCodes.Status400BadRequest
            };
            return new BadRequestObjectResult(problemDetails);
        }

        var entity = department.MapCreateToEntity();
        await _repo.AddDepartmentAsync(entity);
        return CreatedAtRoute(
            "GetDept",
            new
            {
                Id = entity.Id,
            },
            entity);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(cDepartment department, int id)
    {
        var entity = department.MapCreateToEntity();
        entity.Id = id;
        var updated = await _repo.UpdateDepartmentAsync(entity);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var deleted = await _repo.DeleteDepartmentAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    private async Task<bool> ValidateDepartment(ICompanyRepository repo, string name)
    {
        var departments = await repo.GetDepartmentsAsync();
        var match = departments.SingleOrDefault(d => d.DepartmentName == name);
        if (match != null) return false;
        return true;
    }
}