namespace EMS.Core;

public class rDepartment
{
    public int Id { get; set; }

    public string DepartmentName { get; set; }

    public ICollection<rEmployee> Employees { get; set; } = Enumerable.Empty<rEmployee>().ToList();

    public int DepartmentSize => Employees.Count;
}
