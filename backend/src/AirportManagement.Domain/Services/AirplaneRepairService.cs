using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Domain.Services;

public class AirplaneRepairService(int id, string type, string description, decimal pricePerHour)
    : RepairService(id, type, description, pricePerHour)
{
    [Required] public DateTimeOffset StartDate { get; set; }
    [Required] public DateTimeOffset EndDate { get; set; }

    public decimal ElapsedHours => (decimal)(EndDate.TotalOffsetMinutes - StartDate.TotalOffsetMinutes) / 60;
}