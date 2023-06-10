namespace PcBuilders.Learning.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}