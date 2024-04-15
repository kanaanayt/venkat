namespace EMS.Core;

public class eDepartment
{
    public int Id { get; set; }

    public string DepartmentName { get; set; }

    public List<eEmployee> Employees { get; set; }
}
