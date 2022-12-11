using Shipping.Infra.Helpers;
using Shipping.Infra.Models;

namespace Shipping.Test.MockData
{
    public class ShipmentMockData
    {
        public static Shipment NewShipment()
        {
            return new Shipment
            {
                Id = 1,
                CreatedBy = "user 1",
                ServiceId = 1,
                Height = 150,
                Length = 150,
                Weight = 150,
                Width = 150,
                MeasurementType = (int)Enums.MeasurementType.Metric,
                CreatedAt = DateTime.Now
            };
        }
    }
}
