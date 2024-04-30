using EMS.Core;

namespace EMS.Web.Services;

public static class HardCodedData
{
    private static List<rEmployee> _employees = default!;
    private static List<rDepartment> _departments = default!;

    public static IEnumerable<rEmployee> Employees => _employees;
    public static IEnumerable<rDepartment> Departments => _departments;

    static HardCodedData()
    {
        _employees ??= InitializeEmployees();
        _departments ??= InitializeDepartments();
    }

    private static List<rDepartment> InitializeDepartments()
    {
        return new List<rDepartment>
        {
            new rDepartment
            {
                Id = 1,
                DepartmentName = "HR",
                Employees = new List<rEmployee>
                {
                    _employees[0], _employees[5]
                }
            },
            new rDepartment
            {
                Id = 2,
                DepartmentName = "IT",
                Employees = new List<rEmployee>
                {
                    _employees[1], _employees[4]
                }
            },
            new rDepartment
            {
                Id = 3,
                DepartmentName = "Admin",
                Employees = new List<rEmployee>
                {
                    _employees[2], _employees[3]
                }
            }
        };
    }

    private static List<rEmployee> InitializeEmployees()
    {
        return new List<rEmployee>
        {
            new rEmployee
            {
                Id = 1,
                FirstName = "Harry",
                LastName = "Smith",
                Email = "johnsmith@gmail.com",
                JoinDate = new DateTime(2020, 12, 24),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/harry.png"
            },
            new rEmployee
            {
                Id = 2,
                FirstName = "Mary",
                LastName = "Sutherland",
                Email = "marysutherland@gmail.com",
                JoinDate = new DateTime(2022, 4, 21),
                Gender = Gender.Female,
                DepartmentId = 2,
                PhotoPath = "images/mary.png"
            },
            new rEmployee
            {
                Id = 3,
                FirstName = "Sam",
                LastName = "Fallon",
                Email = "samfallon@gmail.com",
                JoinDate = new DateTime(2023, 8, 14),
                Gender = Gender.Other,
                DepartmentId = 3,
                PhotoPath = "images/sam.png"
            },
            new rEmployee
            {
                Id = 4,
                FirstName = "Fin",
                LastName = "Harrington",
                Email = "finharrington@gmail.com",
                JoinDate = new DateTime(2019, 5, 2),
                DepartmentId = 3,
                Gender = Gender.Male,
                PhotoPath = "images/harry.png"
            },
            new rEmployee
            {
                Id = 5,
                FirstName = "Max",
                LastName = "Snipe",
                Email = "maxsnipe@gmail.com",
                JoinDate = new DateTime(2017, 9, 2),
                DepartmentId = 2,
                Gender = Gender.Male,
                PhotoPath = "images/max.png"
            },
            new rEmployee
            {
                Id = 6,
                FirstName = "Wesley",
                LastName = "Kemp",
                Email = "wesleykemp@gmail.com",
                JoinDate = new DateTime(2015, 1, 2),
                DepartmentId = 1,
                Gender = Gender.Male,
                PhotoPath = "images/wesley.png"
            }
        };
    }
}