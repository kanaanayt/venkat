namespace EMS.Core;

public class rDepartment
{
    public int Id { get; set; }

    public string DepartmentName { get; set; }

    public List<rEmployee> Employees { get; set; }

    public int DepartmentSize => Employees.Count;
}
