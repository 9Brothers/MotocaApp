namespace Motoca.Core.Domain.Interfaces.Repositories;

public interface ICoreEventRepository
{
    Task<uint> LastSequence(Guid guid);
}