using AirportManagement.Contracts.Airplanes;
using AirportManagement.Contracts.Airports;
using AirportManagement.Contracts.Clients;
using AirportManagement.Contracts.Services;
using AirportManagement.Domain.Airplane;
using AirportManagement.Domain.Airports;
using AirportManagement.Domain.PlaneStay;
using AirportManagement.Domain.Services;
using AirportManagement.Domain.Services.AirplaneRepairService;

namespace AirportManagement.Api.Utils;

public static class ResponseCreator
{
    public static AirplaneResponse CreateAirplaneResponse(Airplane airplane)
    {
        var response = new AirplaneResponse(
            airplane.Id,
            airplane.Classification,
            airplane.PlanePlate,
            airplane.ClientId,
            airplane.MaxLoad,
            airplane.PassengersCapacity,
            airplane.CrewMembers,
            airplane.HasReceivedMaintenance
        );

        if (airplane.Owner is null)
            return response;
        var client = airplane.Owner;
        response.Client = new ClientResponse(client.Id, client.Name, client.Ci, client.Country,
            client.ArrivalRole.ToString(), client.ClientType.ToString());
        return response;
    }

    public static AirportResponse CreateAirportResponse(Airport airport)
    {
        return new AirportResponse(airport.Id, airport.Name, airport.Address, airport.GeographicLocation);
    }

    public static PlaneStayResponse CreatePlaneStayResponse(PlaneStay planeStay)
    {
        var airportResponse = CreateAirportResponse(planeStay.Airport);
        var airplaneResponse = CreateAirplaneResponse(planeStay.Airplane);

        return new PlaneStayResponse(planeStay.Id, planeStay.ArrivalDate, planeStay.DepartureDate,
            airportResponse, airplaneResponse);
    }

    public static RepairServiceResponse CreateRepairServiceResponse(RepairService repairService)
    {
        return new RepairServiceResponse(repairService.Id, repairService.Description, repairService.FacilityId,
            repairService.Price, repairService.Type);
    }

    public static AirplaneRepairServiceResponse CreateAirplaneRepairServiceResponse(
        AirplaneRepairService airplaneRepairService)
    {
        return new AirplaneRepairServiceResponse(
            airplaneRepairService.Id,
            airplaneRepairService.AirPlaneId,
            airplaneRepairService.RepairServiceId,
            airplaneRepairService.StartDate,
            airplaneRepairService.EndDate,
            airplaneRepairService.ElapsedHours);
    }
}