using Microsoft.Extensions.Logging;
using Moq;
using Shipping.Controllers;
using Shipping.Infra.Validations;
using Shipping.Services.Services;
using Shipping.Test.MockData;

namespace Shipping.Test.System.Controllers
{
    public class TestShipmentController : BaseTest
    {
        private Mock<IShipmentService> shipmentService;
        private Mock<ILogger<ShipmentController>> loggerService;
        private Mock<IServiceService> serviceService;

        [Theory]
        [InlineData(90, 1)]
        [InlineData(160, 0)]
        [InlineData(0, 1)]
        public void PostShipment_WithInvalidData(int width, int measurementType)
        {
            /// Arrange
            var newShipment = ShipmentMockData.NewShipment();
            newShipment.Width = width;
            newShipment.MeasurementType = measurementType;
            /// Assert
            var val = new PostShipmentValidator().Validate(newShipment);
             Assert.False(val.IsValid);
        }

            [Fact]
        public void PostShipment_ShouldCall_IShipmentService_Create_AtleastOnce()
        {
            /// Arrange
            ArrangeServices();

            var sut = new ShipmentController(loggerService.Object, shipmentService.Object, serviceService.Object);
            var newShipment = ShipmentMockData.NewShipment();
            shipmentService.Setup(x => x.Create(newShipment))
                .Returns(ShipmentMockData.NewShipment);
            /// Act
            var result = sut.Post(newShipment);

            /// Assert
            shipmentService.Verify(_ => _.Create(newShipment), Times.Once());
        }

        private void ArrangeServices()
        {
            shipmentService = new Mock<IShipmentService>();
            loggerService = new Mock<ILogger<ShipmentController>>();
            serviceService = new Mock<IServiceService>();

            var serviceProvider = ServiceProviderMockData.NewServiceProvider();
            var newService = ServiceMockData.NewService();
            ctx.ServiceProviders.Add(serviceProvider);
            ctx.Services.Add(newService);
            ctx.SaveChanges();

            serviceService.Setup(x => x.FindById(newService.Id))
          .Returns(ServiceMockData.NewService);
        }
    }
}
