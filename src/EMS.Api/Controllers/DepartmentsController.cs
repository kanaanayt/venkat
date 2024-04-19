using EMS.Api.BackendRepository;
using EMS.Core;
using Microsoft.AspNetCore.Mvc;

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
    public async Task<IEnumerable<rDepartment>> GetDepartments()
    {
        return await _repo.GetDepartmentsAsync();
    }
    
    
}