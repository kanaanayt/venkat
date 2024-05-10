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
            Employees = entity.Employees
                              .Select(MapEntityToEmployee)
                              .ToList()
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
            DepartmentId = entity.DepartmentId,
            PhotoPath = entity.PhotoPath
        };
    }

    public static rEmployees MapEntitiesToEmployees(this IEnumerable<eEmployee> entities)
    {
        return new rEmployees
        {
            Items = entities.Select(MapEntityToEmployee)
        };
    }

    public static eDepartment MapCreateToEntity(this cDepartment department)
    {
        return new eDepartment
        {
            DepartmentName = department.DepartmentName
        };
    }


    public static eEmployee MapCreateToEntity(this cEmployee employee, int departmentId)
    {
         return new eEmployee
         {
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            Email = employee.Email,
            JoinDate = employee.JoinDate,
            Gender = employee.Gender,
            DepartmentId = departmentId,
            PhotoPath = employee.PhotoPath
         };
    }
}


