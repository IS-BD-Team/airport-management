using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Domain.Services;

namespace AirportManagement.Domain.Clients;

public class ClientRating(int rating, int planeStayId, int serviceId)
{
    [Required] public int Id { get; init; }

    [Required] public int PlaneStayId { get; set; } = planeStayId;
    [ForeignKey(nameof(PlaneStayId))] public PlaneStay.PlaneStay PlaneStay { get; set; } = null!;

    [Required] public int ServiceId { get; init; } = serviceId;
    [ForeignKey(nameof(ServiceId))] public Service? Service { get; set; }

    [Required] public int Rating { get; set; } = rating;
}