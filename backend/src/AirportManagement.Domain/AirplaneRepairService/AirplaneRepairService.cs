using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Domain.RepairServices;
using AirportManagement.Domain.Services;

namespace AirportManagement.Domain.AirplaneRepairService;

public class AirplaneRepairService(int airPlaneId, int repairServiceId, DateTime startDate, DateTime endDate)
{
    [Key] public int Id { get; init; }

    [Required] public int AirPlaneId { get; set; } = airPlaneId;
    [ForeignKey(nameof(AirPlaneId))] public Airplane.Airplane? Plane { get; set; }

    [Required] public int RepairServiceId { get; set; } = repairServiceId;
    [ForeignKey(nameof(RepairServiceId))] public RepairService RepairService { get; set; } = null!;

    [Required] public DateTime StartDate { get; set; } = startDate;
    [Required] public DateTime EndDate { get; set; } = endDate;

    [Required] public DateTime CreationDate { get; private init; } = DateTime.UtcNow;


    public decimal ElapsedHours => (decimal)(EndDate - StartDate).TotalHours;
}