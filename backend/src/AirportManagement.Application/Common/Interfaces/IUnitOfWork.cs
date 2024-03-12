namespace AirportManagement.Application.Common.Interfaces;

public interface IUnitOfWork
{
    Task CommitChangesAsync();
}