using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Commands.CreatePlaneStay;

public record CreatePlaneStayCommand(int PlaneId, int AirportId, DateTime ArrivalDate, DateTime DepartureDate)
    : IRequest<ErrorOr<PlaneStay>>;