using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportManagement.Domain.Services;

public class Service(string description, int facilityId, decimal price)
{
    [Key] public int Id { get; init; }

    [Required] public string Description { get; set; } = description;
    [Required] public int FacilityId { get; set; } = facilityId;

    [ForeignKey(nameof(FacilityId))] public Facility.Facility? Facility { get; set; }

    public decimal Price { get; set; } = price;
}