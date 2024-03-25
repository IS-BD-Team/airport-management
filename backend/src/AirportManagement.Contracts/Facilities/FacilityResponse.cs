namespace AirportManagement.Contracts.Facilities;

public record FacilityResponse(
    int FacilityId,
    string? Name,
    string Type,
    string Location);