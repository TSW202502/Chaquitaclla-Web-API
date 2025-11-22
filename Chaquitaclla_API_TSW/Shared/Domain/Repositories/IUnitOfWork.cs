namespace Chaquitaclla_API_TSW.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}
