using System.Reflection.Emit;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using EMS.Core;

namespace EMS.Api.Mapping;

public static class ContractMappings
{
    public static rDepartment MapEntityToDepartment(this eDepartment entity)
    {
        return new rDepartment()
        {
            Id = entity.Id,
            DepartmentName = entity.DepartmentName,
            Employees = new Collection<rEmployee>(entity.Employees.Select(MapEntityToEmployee).ToList())
        };
    }

    public static rEmployee MapEntityToEmployee(this eEmployee entity)
    {
        return new rEmployee()
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            JoinDate = entity.JoinDate,
            Gender = entity.Gender.ValueOf();
        };
    }

    public static rEmployees MapEntitiesToEmployees(this IEnumerable<eEmployee> entities)
    {
        return new rEmployees()
        {
            Items = entities.Select(MapEntityToEmployee)
        };
    }

    public static rDepartment MapEntityToDepartment(this eDepartment entity)
    {

    }
}
