using System.Reflection.Emit;
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
        return _httpClient.PostAsJsonAsync("api/departments", department);
    }

    public async Task DeleteDepartment(int id)
    {
        await _httpClient.DeleteFromJsonAsync<rDepartment>($"api/departments/{id}");
    }

    public async Task<rDepartment> GetDepartment(int id)
    {
        var response = await _httpClient.GetAsync($"api/departments/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return new rDepartment();
        }
        return await response.Content.ReadFromJsonAsync<rDepartment>();
    }

    public async Task<rDepartments> GetDepartments()
    {
        var departments = await _httpClient.GetFromJsonAsync<rDepartments>("api/departments");
        return departments!;
    }

    public async Task UpdateDepartment(cDepartment department, int id)
    {
        await _httpClient.PutAsJsonAsync($"api/departments/{id}", department);
    }

    public async Task AddEmployee(int departmentId, cEmployee employee)
    {
        await _httpClient.PostAsJsonAsync($"api/departments/{departmentId}/employees", employee);
    }

    public async Task DeleteEmployee(int departmentId, int employeeId)
    {
        await _httpClient.DeleteFromJsonAsync<rEmployee>($"api/departments/{departmentId}/employees/{employeeId}");
    }

    public async Task<rEmployees> GetAllEmployees()
    {
        return await _httpClient.GetFromJsonAsync<rEmployees>("api/employees");
    }

    public async Task<rEmployees> GetDepartmentEmployees(int departmentId)
    {
        return await _httpClient.GetFromJsonAsync<rEmployees>($"api/departments/{departmentId}/employees");
    }

    public async Task<rEmployee> GetEmployee(int departmentId, int employeeId)
    {
        var response = await _httpClient.GetAsync($"api/departments/{departmentId}/employees/{employeeId}");
        if (response.StatusCode == HttpStatusCode.NotFound)
        {
            return await Task.FromResult(new rEmployee());
        }
        return await response.Content.ReadFromJsonAsync<rEmployee>();
    }

    public async Task<rEmployees> Search(string employeeName)
    {
        return await _httpClient.GetFromJsonAsync<rEmployees>($"api/employees/search?search={employeeName}");
    }

    public async Task UpdateEmployee(int departmentId, int employeeId, cEmployee employee)
    {
        await _httpClient.PutAsJsonAsync($"api/departments/{departmentId}/employees/{employeeId}", employee);

    }
}
