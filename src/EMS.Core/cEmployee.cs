using System.ComponentModel.DataAnnotations;

namespace EMS.Core;
public class cEmployee
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public DateTime JoinDate { get; set; }

    public Gender Gender { get; set; }

    public string PhotoPath { get; set; } = string.Empty; 
}