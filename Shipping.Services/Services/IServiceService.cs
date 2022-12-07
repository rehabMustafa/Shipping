using Shipping.Infra.Models;

namespace Shipping.Services.Services
{
    public interface IServiceService
    {
        Service FindById(int id);
    }
}
