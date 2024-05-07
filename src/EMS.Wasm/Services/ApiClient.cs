using System.Net;
using System.Net.Http.Json;
using EMS.Core;
using EMS.Web.Services;

namespace EMS.Wasm.Services;

public class ApiClient : IEmployeesService, IDepartmentService
{
    private readonly HttpClient _httpClient;
    public ApiClient(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }

    public Task AddDepartment(cDepartment department)
    {
        throw new NotImplementedException();
    }

    public Task DeleteDepartment(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<rDepartment> GetDepartment(int id)
    {
        string body = await _httpClient.GetStringAsync("api/departments/id");
        Console.WriteLine(body);
        return new rDepartment();
        // var rDepartment = await _httpClient.GetFromJsonAsync<rDepartment>("api/departments/id");
        // return rDepartment;
    }

    public async Task<rDepartments> GetDepartments()
    {
        var departments = await _httpClient.GetFromJsonAsync<rDepartments>("api/departments");
        return departments!;
    }

    public Task UpdateDepartment(cDepartment department, int id)
    {
        throw new NotImplementedException();
    }

        public Task AddEmployee()
    {
        throw new NotImplementedException();
    }

    public Task DeleteEmployee()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<rEmployees>> GetAllEmployees()
    {
        throw new NotImplementedException();
    }

    public Task<rEmployees> GetDepartmentDemployees(int id)
    {
        throw new NotImplementedException();
    }

    public Task<rEmployee> GetEmployee(int departmentId, int employeeId)
    {
        throw new NotImplementedException();
    }

    public Task<rEmployees> Search(string search)
    {
        throw new NotImplementedException();
    }

    public Task UpdateEmployee()
    {
        throw new NotImplementedException();
    }
}
