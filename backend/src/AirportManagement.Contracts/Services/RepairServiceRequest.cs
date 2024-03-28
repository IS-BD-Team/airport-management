namespace AirportManagement.Contracts.Services;

public record RepairServiceRequest(string Description, int FacilityId, decimal Price, string Type);