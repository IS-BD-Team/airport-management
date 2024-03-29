using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Services;

public class RepairService(string description, int facilityId, decimal price, string type)
    : Service(description, facilityId, price)
{
    [Required] public string Type { get; set; } = type;
}