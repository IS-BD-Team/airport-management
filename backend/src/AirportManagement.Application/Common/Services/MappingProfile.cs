using AirportManagement.Application.DTO;
using AirportManagement.Domain.Airplane;
using AirportManagement.Domain.Airports;
using AirportManagement.Domain.Clients;
using AirportManagement.Domain.Facility;
using AirportManagement.Domain.PlaneStay;
using AirportManagement.Domain.RepairServices;
using AirportManagement.Domain.Services;
using AutoMapper;

namespace AirportManagement.Application.Common.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Airplane, AirplaneDto>();
        CreateMap<Domain.AirplaneRepairService.AirplaneRepairService, AirplaneRepairServiceDto>();
        CreateMap<Airport, AirportDto>();
        CreateMap<Client, ClientDto>();
        CreateMap<Domain.Clients.ClientRating, ClientRatingDto>();
        CreateMap<Facility, FacilityDto>();
        CreateMap<PlaneStay, PlaneStayDto>();
        CreateMap<Service, ServiceDto>();
        CreateMap<RepairService, RepairServiceDto>();
    }
}