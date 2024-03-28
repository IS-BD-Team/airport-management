namespace AirportManagement.Contracts.Services;

public record RepairServiceResponse(
    int Id,
    string Description,
    int FacilityId,
    decimal Price,
    string Type);