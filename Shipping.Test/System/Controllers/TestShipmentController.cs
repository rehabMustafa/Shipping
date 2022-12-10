//using Microsoft.Extensions.Logging;
//using Moq;
//using Shipping.Controllers;
//using Shipping.Infra.Models;
//using Shipping.Services.Services;
//using Shipping.Test.MockData;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Shipping.Test.System.Controllers
//{
//    public class TestShipmentController: BaseTest
//    {
//        [Fact]
//        public void PostShipment_ShouldCall_IShipmentService_Create_AtleastOnce()
//        {
//            /// Arrange
//            var shipmentService = new Mock<IShipmentService>();
//            var loggerService = new Mock<ILogger<ShipmentController>>();
//            var serviceService = new Mock<IServiceService>();
//            var serviceProvider = ServiceProviderMockData.NewServiceProvider();
//            var newService = ServiceMockData.NewService();
//            ctx.ServiceProviders.Add(serviceProvider);
//            ctx.Services.Add(newService);
//            var res = ctx.SaveChanges();
//            var newShipment = ShipmentMockData.NewShipment();
//            var sut = new ShipmentController(loggerService.Object, shipmentService.Object, serviceService.Object);

//            /// Act
//            var result = sut.Post(newShipment);

//            /// Assert
//            shipmentService.Verify(_ => _.Create(newShipment), Times.Exactly(1));
//        }
//    }
//}
