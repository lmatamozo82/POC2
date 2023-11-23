
using Deneva.Core.Domain.Models.RequestAttributes;
using Deneva.Core.Domain.PrimaryPorts.RequestAttributes;
using Deneva.Core.Domain.SecondaryPorts.Persistencia.RequestAttributes;

namespace Deneva.Core.Application.PrimaryPorts.RequestAttributes
{
    public class GetByObjIDStructRequestAttributes : IGetStructRequestAttributesByObjID
    {
        private readonly IStructRequestAttributesRepository repo;

        public GetByObjIDStructRequestAttributes(IStructRequestAttributesRepository repo)
        {
            this.repo = repo;
        }
        public async Task<StructRequestAttributes> ExecuteAsync(int objID)
        {
            return await repo.GetByObjIDAsync(objID);
        }
    }
}