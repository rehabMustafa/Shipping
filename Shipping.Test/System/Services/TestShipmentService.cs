using Microsoft.Extensions.Logging;
using Moq;
using Shipping.Controllers;
using Shipping.Infra.Repositories;
using Shipping.Services.Services;
using Shipping.Test.MockData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.Test.System.Services
{
    public class TestShipmentService: BaseTest
    {
        [Fact]
        public void PostShipment_ShouldCall_IShipmentService_Create_AtleastOnce()
        {
            /// Arrange
            var shipmentRepo = new Mock<IShipmentRepository>();
            var serviceProvider = ServiceProviderMockData.NewServiceProvider();
            var newService = ServiceMockData.NewService();
            ctx.ServiceProviders.Add(serviceProvider);
            ctx.Services.Add(newService);
            var res = ctx.SaveChanges();
            var newShipment = ShipmentMockData.NewShipment();
            var sut = new ShipmentService(shipmentRepo.Object);

            /// Act
            var result = sut.Create(newShipment);

            /// Assert
            shipmentRepo.Verify(_ => _.Post(newShipment), Times.Exactly(1));
        }
    }
}
