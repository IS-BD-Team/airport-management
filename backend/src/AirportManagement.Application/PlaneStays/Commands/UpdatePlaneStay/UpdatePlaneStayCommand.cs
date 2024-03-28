using AirportManagement.Domain.PlaneStay;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Commands.UpdatePlaneStay;

public record UpdatePlaneStayCommand(int StayId, int PlaneId, int AirportId, DateTime Start, DateTime End)
    : IRequest<ErrorOr<PlaneStay>>;