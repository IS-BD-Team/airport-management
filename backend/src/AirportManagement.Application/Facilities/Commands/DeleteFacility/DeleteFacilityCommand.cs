using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Facilities.Commands.DeleteFacility;

public record DeleteFacilityCommand(int FacilityId) : IRequest<ErrorOr<Success>>;