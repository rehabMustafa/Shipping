using Shipping.Infra.Helpers;
using Shipping.Infra.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Test.MockData
{
    public class ShipmentMockData
    {
        public static Shipment NewShipment()
        {
            return new Shipment
            {
                Id = 0,
                CreatedBy = "user 1",
                ServiceId = 1,
                Height = 500,
                Length = 500,
                Weight = 500,
                Width = 500,
                MeasurementType = (int)Enums.MeasurementType.Metric,
                CreatedAt = DateTime.Now
            };
        }
    }
}
