using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.Core;

public class eEmployee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime JoinDate { get; set; }

    public eGender Gender { get; set; }

    public int DepartmentId { get; set; }
    public eDepartment? Department { get; set; }

    public string PhotoPath { get; set; } = string.Empty;
}
