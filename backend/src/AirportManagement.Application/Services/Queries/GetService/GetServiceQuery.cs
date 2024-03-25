using AirportManagement.Domain.Services;
using ErrorOr;
using MediatR;

namespace AirportManagement.Application.Services.Queries.GetService;

public record GetServiceQuery(int ServiceId) : IRequest<ErrorOr<Service>>;