namespace Motoca.Platform.Domain.Interfaces.Repositories;

public interface IPlatformEventRepository
{
    Task<uint> LastSequence(Guid guid);
}