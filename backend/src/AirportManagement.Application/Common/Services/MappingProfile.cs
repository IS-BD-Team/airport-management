using AirportManagement.Application.DTO;
using AirportManagement.Domain.Airplane;
using AirportManagement.Domain.Airports;
using AirportManagement.Domain.Clients;
using AirportManagement.Domain.Facility;
using AirportManagement.Domain.PlaneStay;
using AirportManagement.Domain.Services;
using AirportManagement.Domain.Services.AirplaneRepairService;
using AutoMapper;

namespace AirportManagement.Application.Common.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Airplane, AirplaneDto>();
        CreateMap<AirplaneRepairService, AirplaneRepairServiceDto>();
        CreateMap<Airport, AirportDto>();
        CreateMap<Client, ClientDto>();
        CreateMap<Facility, FacilityDto>();
        CreateMap<PlaneStay, PlaneStayDto>();
        CreateMap<Service, ServiceDto>();
        CreateMap<RepairService, RepairServiceDto>();
    }
}