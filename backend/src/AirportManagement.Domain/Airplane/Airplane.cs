using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Domain.Clients;
using AirportManagement.Domain.Services;

namespace AirportManagement.Domain.Airplane;

public class Airplane(
    string classification,
    int clientId,
    int maxLoad,
    int passengersCapacity,
    int crewMembers
)
{
    [Key] public int Id { get; init; }

    [Required] public string Classification { get; set; } = classification;

    //TODO: 
    // [Required] public string PlanePlate { get; init; } = planePlate;
    [Required] public int ClientId { get; set; } = clientId;
    [ForeignKey(nameof(ClientId))] public Client? Owner { get; set; }

    [Required] public int MaxLoad { get; set; } = maxLoad;
    [Required] public int PassengersCapacity { get; set; } = passengersCapacity;

    [Required] public int CrewMembers { get; set; } = crewMembers;

    [Required] public bool HasReceivedMaintenance { get; set; } = false;

    public ICollection<Service>? Services { get; set; }
}