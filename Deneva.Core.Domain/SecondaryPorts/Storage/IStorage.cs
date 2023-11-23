using Deneva.Core.Domain.Models.Base;

namespace Deneva.Core.Domain.SecondaryPorts.Storage
{
    public interface IStorage<T> : IDisposable where T : IAggregateRoot
    {

    }
}
