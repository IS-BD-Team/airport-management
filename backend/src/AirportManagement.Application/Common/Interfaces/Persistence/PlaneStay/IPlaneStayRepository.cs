using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence.PlaneStay;

public interface IPlaneStayRepository
{
    Task<Success> AddAsync(Domain.PlaneStay.PlaneStay planeStay);
    Task<Success> DeleteAsync(int planeStayId);
    Task<Domain.PlaneStay.PlaneStay?> GetByIdAsync(int planeStayId);
    Task<Domain.PlaneStay.PlaneStay?> UpdateAsync(int planeStayId, Domain.PlaneStay.PlaneStay planeStay);
    Task<IQueryable<Domain.PlaneStay.PlaneStay>> GetAllAsync();
}