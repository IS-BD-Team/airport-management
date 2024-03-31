using ErrorOr;

namespace AirportManagement.Application.Common.Interfaces.Persistence;

public interface IRepository<T> where T : class
{
    Task<Success> AddAsync(T input);
    Task<Success> DeleteAsync(int id);
    Task<T?> GetByIdAsync(int id);
    Task<T?> UpdateAsync(int id, T input);
    Task<IEnumerable<T>> GetAllAsync();
}