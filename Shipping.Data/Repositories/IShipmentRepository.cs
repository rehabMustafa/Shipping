using Shipping.Infra.Models;

namespace Shipping.Infra.Repositories
{
    public interface IShipmentRepository
    {
        Shipment Post(Shipment shipment);
    }
}
