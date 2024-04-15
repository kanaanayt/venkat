using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Core;

public class eDepartment
{
    [Key] 
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string DepartmentName { get; set; }

    public ICollection<eEmployee> Employees { get; set; }
}
