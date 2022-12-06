using Shipping.Infra.Models;

namespace Shipping.Services.Services
{
    public interface IShipmentService
    {
        Shipment Create(Shipment shipment);
    }
}
