using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Services;

public class RepairService(int id, string type, string description, decimal pricePerHour)
{
    [Key] public int Id { get; set; } = id;

    [Required] public string Type { get; set; } = type;

    [Required] public string Description { get; set; } = description;

    [Required] public decimal PricePerHour { get; set; } = pricePerHour;
}