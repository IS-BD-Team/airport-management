namespace AirportManagement.Contracts.ClientRating;

public record ClientRatingRequest(int PlaneStayId, int ServiceId, int Rating);