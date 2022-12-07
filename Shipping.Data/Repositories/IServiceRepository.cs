using Shipping.Infra.Models;

namespace Shipping.Infra.Repositories
{
    public interface IServiceRepository
    {
        Service FindById(int id);

    }
}
