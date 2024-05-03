using AutoMapper;
using EMS.Api.BackendRepository;
using EMS.Api.Mapping;
using EMS.Core;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Controllers;

[ApiController]
[Route("/api/departments")]
public class DepartmentsController : ControllerBase
{
    private readonly ICompanyRepository _repo;
    private readonly IMapper _mapper;
    
    public DepartmentsController(ICompanyRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<rDepartments>> GetDepartments()
    {
        var entities = await _repo.GetDepartmentsAsync();
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
}