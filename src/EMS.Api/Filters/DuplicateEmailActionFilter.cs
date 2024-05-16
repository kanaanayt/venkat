using System.Security.Cryptography;
using System.Reflection.Emit;
using Microsoft.AspNetCore.Mvc.Filters;
using EMS.Api.BackendRepository;
using EMS.Core;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Api.Filters;

public class DuplicateEmailActionFilter : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(
        ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var repo = context.HttpContext.RequestServices.GetService<ICompanyRepository>();
        var employee = context.ActionArguments["employee"] as cEmployee;
        
        var employees = await repo.GetAllEmployeesAsync();

        var email = employees.FirstOrDefault(e => e.Email == employee.Email);
        var lastName = employees.FirstOrDefault(e => e.LastName.Equals(employee.LastName, StringComparison.OrdinalIgnoreCase));
        if (email != null) context.ModelState.AddModelError("email", "Email already in use");
        if (lastName != null) context.ModelState.AddModelError("last name", "Last Name already in use");
        if (!context.ModelState.IsValid) context.Result = new BadRequestObjectResult(context.ModelState);
    }
}