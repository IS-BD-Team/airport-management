using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Entities;

public class User(string firstName, string lastname, string email, string password, bool isSuperAdmin = false)
{
    [Required] public int Id { get; set; }

    [Required] public string FirstName { get; set; } = firstName;

    [Required] public string Lastname { get; set; } = lastname;

    [Key] [Required] public string Email { get; set; } = email;

    [Required] public string Password { get; set; } = password;

    public bool IsSuperAdmin { get; set; } = isSuperAdmin;
}