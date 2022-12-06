using Shipping.Infra.Models;
using Shipping.Infra.Repositories;

namespace Shipping.Services.Services
{
    public class ShipmentService: IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }
        public Shipment Create(Shipment shipment)
        {
            return _shipmentRepository.Post(shipment);
        }
    }
}
