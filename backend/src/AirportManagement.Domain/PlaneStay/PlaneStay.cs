using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Domain.Airports;
using AirportManagement.Domain.Clients;

namespace AirportManagement.Domain.PlaneStay;

public class PlaneStay(int airplaneId, int airportId, DateTime arrivalDate, DateTime departureDate)
{
    [Key] public int Id { get; init; }

    [Required] public int AirportId { get; set; } = airportId;
    [ForeignKey(nameof(AirportId))] public Airport Airport { get; set; } = null!;

    [Required] public int AirplaneId { get; set; } = airplaneId;
    [ForeignKey(nameof(AirplaneId))] public Airplane.Airplane Airplane { get; set; } = null!;

    [Required] public DateTime ArrivalDate { get; set; } = arrivalDate;
    [Required] public DateTime DepartureDate { get; set; } = departureDate;

    public ICollection<ClientRating> Ratings { get; set; } = new List<ClientRating>();
}