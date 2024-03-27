namespace AirportManagement.Contracts.ClientRating;

public record ClientRatingResponse(int ClientRatingId, int ClientId, int ServiceId, int Rating);