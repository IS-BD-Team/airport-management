namespace AirportManagement.Contracts.Services;

public record ServiceResponse(
    int ServiceId,
    string Description,
    int FacilityId,
    decimal Price);