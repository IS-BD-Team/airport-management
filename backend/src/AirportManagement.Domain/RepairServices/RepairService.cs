using System.ComponentModel.DataAnnotations;
using AirportManagement.Domain.Services;

namespace AirportManagement.Domain.RepairServices;

public class RepairService(string description, int facilityId, decimal price, string type)
    : Service(description, facilityId, price)
{
    [Required] public string Type { get; set; } = type;
}