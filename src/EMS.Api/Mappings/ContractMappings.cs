using System.Reflection.Emit;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using EMS.Core;
using Microsoft.AspNetCore.Http.Features;

namespace EMS.Api.Mapping;

public static class ContractMappings
{
    public static rDepartment MapEntityToDepartment(this eDepartment entity)
    {
        return new rDepartment()
        {
            Id = entity.Id,
            DepartmentName = entity.DepartmentName,
            Employees = new Collection<rEmployee>(entity.Employees
                                                        .Select(MapEntityToEmployee)
                                                        .ToList())
        };
    }

    public static rDepartments MapEntitiesToDepartments(this IEnumerable<eDepartment> entities)
    {
        return new rDepartments
        {
            Items = entities.Select(MapEntityToDepartment)
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
            Gender = entity.Gender,
            DepartmentId = entity.DepartmentId
        };
    }

    public static rEmployees MapEntitiesToEmployees(this IEnumerable<eEmployee> entities)
    {
        return new rEmployees()
        {
            Items = entities.Select(MapEntityToEmployee)
        };
    }


}

