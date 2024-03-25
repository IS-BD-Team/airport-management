namespace AirportManagement.Contracts.Facilities;

public record FacilityRequest(
    string? Name,
    string Type,
    string Location);