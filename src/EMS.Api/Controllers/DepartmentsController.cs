using AutoMapper;
using EMS.Api.BackendRepository;
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

    [HttpGet(Name = "GetDept")]
    public async Task<ActionResult<IEnumerable<rDepartment>>> GetDepartments()
    {
        var entities = await _repo.GetDepartmentsAsync();
        return Ok(_mapper.Map<IEnumerable<rDepartment>>(entities));
    }

    [HttpGet("id")]
    public async Task<ActionResult<rDepartment>> GetDepartment(int id)
    {
        var entity = await _repo.GetDepartmentAsync(id);
        return Ok(_mapper.Map<rDepartment>(entity));
    }

    [HttpPost]
    public async Task<ActionResult<rDepartment>> AddDepartment(cDepartment department)
    {
        var entity = _mapper.Map<eDepartment>(department);
        await _repo.AddDepartmentAsync(entity);
        var dto = _mapper.Map<rDepartment>(entity);
        return CreatedAtRoute(
            "GetDept",
            new
            {
                Id = entity.Id,
            },
            dto);
    }

}