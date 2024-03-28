using ErrorOr;
using MediatR;

namespace AirportManagement.Application.PlaneStays.Commands.DeletePlaneStay;

public record DeletePlaneStayCommand(int StayId) : IRequest<ErrorOr<Success>>;