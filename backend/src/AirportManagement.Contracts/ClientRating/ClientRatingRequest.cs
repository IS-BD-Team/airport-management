namespace AirportManagement.Contracts.ClientRating;

public record ClientRatingRequest(int ClientId, int ServiceId, int Rating);