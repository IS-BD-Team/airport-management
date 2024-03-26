using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Domain.Services;

namespace AirportManagement.Domain.Clients;

public class ClientRating(int rating, int clientId, int serviceId)
{
    [Required] public int Id { get; init; }
    [Required] public int ClientId { get; set; } = clientId;

    [ForeignKey(nameof(ClientId))] public Clients.Client? Client { get; set; }

    [Required] public int ServiceId { get; set; } = serviceId;

    [ForeignKey(nameof(ServiceId))] public Service? Service { get; set; }

    public int Rating { get; set; } = rating;
}