using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Queries.GetAllServices;

public record GetAllServicesQuery : IRequest<ErrorOr<IEnumerable<Service>>>;