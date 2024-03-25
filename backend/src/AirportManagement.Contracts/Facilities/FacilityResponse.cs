using AirportManagement.Contracts.Services;

namespace AirportManagement.Contracts.Facilities;

public record FacilityResponse(
    int FacilityId,
    string? Name,
    string Type,
    string Location,
    List<ServiceResponse>? Services = null);