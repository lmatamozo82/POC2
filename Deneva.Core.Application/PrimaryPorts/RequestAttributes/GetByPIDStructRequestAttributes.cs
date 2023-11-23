using Deneva.Core.Domain.Builders.RequestAttributes;
using Deneva.Core.Domain.Models.RequestAttributes;
using Deneva.Core.Domain.PrimaryPorts.RequestAttributes;
using Deneva.Core.Domain.SecondaryPorts.Persistencia.RequestAttributes;

namespace Deneva.Core.Application.PrimaryPorts.RequestAttributes
{
    public class GetByPIDStructRequestAttributes : IGetByPIDStructRequestAttributes
    {
        private readonly IStructRequestAttributesRepository repo;

        public GetByPIDStructRequestAttributes(IStructRequestAttributesRepository repo)
        {
            this.repo = repo;
        }
        public async Task<StructRequestAttributes> ExecuteAsync(string PID)
        {
            return await repo.GetByPIDAsync(PID);
        }
    }
}
