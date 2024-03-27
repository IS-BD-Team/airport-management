namespace AirportManagement.Contracts.Services;

public record ServiceRequest(
    string Description,
    int FacilityId,
    decimal Price);