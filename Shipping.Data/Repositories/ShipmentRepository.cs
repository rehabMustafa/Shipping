using Shipping.Data;
using Shipping.Infra.Models;

namespace Shipping.Infra.Repositories
{
    public class ShipmentRepository: IShipmentRepository
    {
        private readonly ShippingContext ctx;
        public ShipmentRepository(ShippingContext ctx)
        {
            this.ctx = ctx;
        }
        public Shipment Post(Shipment shipment)
        {
            ctx.Shipments.Add(shipment);
            ctx.SaveChanges();
            return shipment;
        }
    }
}
