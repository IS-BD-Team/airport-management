using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Domain.Clients;
using AirportManagement.Domain.Services;

namespace AirportManagement.Domain.Airplane;

public class Airplane(
    string classification,
    int clientId,
    int maxLoad,
    DateTimeOffset arriveDate,
    DateTimeOffset departureDate)
{
    [Key] public int Id { get; init; }

    public string Classification { get; set; } = classification;
    [Required] public int ClientId { get; set; } = clientId;
    [ForeignKey(nameof(ClientId))] private Client? Owner { get; set; }

    [Required] public int MaxLoad { get; set; } = maxLoad;
    [Required] public int PassengersCapacity { get; set; }

    [Required] public DateTimeOffset ArriveDate { get; set; } = arriveDate;
    [Required] public DateTimeOffset DepartureDate { get; set; } = departureDate;

    [Required] public bool HasReceivedMaintenance { get; set; } = false;

    public ICollection<Service>? Services { get; set; }
}