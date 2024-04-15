namespace EMS.Core;

public class eDepartment
{
    public int Id { get; set; }

    public string DepartmentName { get; set; }

    public ICollection<eEmployee> Employees { get; set; }
}
