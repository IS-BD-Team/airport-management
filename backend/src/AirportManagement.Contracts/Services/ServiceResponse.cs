using AirportManagement.Contracts.Facilities;

namespace AirportManagement.Contracts.Services;

public record ServiceResponse(
    int ServiceId,
    string Description,
    int FacilityId,
    decimal Price,
    FacilityResponse? Facility = null);