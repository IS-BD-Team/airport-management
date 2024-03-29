namespace AirportManagement.Contracts.Services;

public record AirplaneRepairServiceRequest(int AirPlaneId, int RepairServiceId, DateTime StartDate, DateTime EndDate);