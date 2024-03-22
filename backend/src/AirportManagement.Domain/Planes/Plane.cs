using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Domain.Clients;

namespace AirportManagement.Domain.Planes;

public class Plane(
    string classification,
    int id,
    int clientId,
    int maxLoad,
    DateTimeOffset arriveDate,
    DateTimeOffset departureDate)
{
    [Key] public int Id { get; set; } = id;

    public string Classification { get; set; } = classification;
    [Required] public int ClientId { get; set; } = clientId;
    [ForeignKey(nameof(ClientId))] private Client? Owner { get; set; }

    [Required] public int MaxLoad { get; set; } = maxLoad;
    [Required] public int PassengersCapacity { get; set; }

    [Required] public DateTimeOffset ArriveDate { get; set; } = arriveDate;
    [Required] public DateTimeOffset DepartureDate { get; set; } = departureDate;
}