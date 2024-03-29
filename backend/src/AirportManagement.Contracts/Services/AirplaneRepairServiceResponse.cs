namespace AirportManagement.Contracts.Services;

public record AirplaneRepairServiceResponse(
    int Id,
    int AirPlaneId,
    int RepairServiceId,
    DateTime StartDate,
    DateTime EndDate,
    decimal ElapsedHours);