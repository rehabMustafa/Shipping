using Shipping.Infra.Models;
using Shipping.Infra.Repositories;
using Shipping.Infra.Validations;

namespace Shipping.Test.Tests
{
    public class PostShipmentTest: BaseTest
    {
        #region THEORY
        //[Theory]
        //[InlineData(0)]
        //public void Theory_PostUser_ServiceId_NoValidation(int ServiceId)
        //{
        //    var shipment = new Shipment
        //    {
        //        ServiceId = ServiceId
        //    };

        //    var val = new PostShipmentValidator().Validate(shipment);
        //    Assert.False(val.IsValid);
        //}

        //[Theory]
        //[InlineData(0)]
        //public void Theory_PostUser_ServiceId_Validation(int ServiceId)
        //{
        //    var shipment = new Shipment
        //    {
        //        ServiceId = ServiceId
        //    };

        //    var val = new PostShipmentValidator().Validate(shipment);
        //    Assert.False(val.IsValid);
        //}

        [Theory]
        [InlineData(0, 400)]
        public void Theory_PostUser_ServiceId(int ServiceId, int ErrorCode)
        {
            var shipment = new Shipment
            {
                ServiceId = ServiceId
            };

            CheckError(new PostShipmentValidator(), ErrorCode, shipment);

        }
        #endregion

        #region FACT
        //[Fact]
        //public void Fact_PostShipment_NoModelNoRepository()
        //{
        //    var shipment = new Shipment(1, 500, 300, 400, 450, "test user");

        //    // REPOSITORY
        //    ctx.shipments.Add(shipment);
        //    ctx.SaveChanges();

        //    // ASSERT
        //    Assert.Equal(1, shipment.Id);
        //}

        //[Fact]
        //public void Fact_PostShipment_NoRepository()
        //{
        //    var shipment = new Shipment(1, 500, 300, 400, 450, "test user");

        //    // REPOSITORY
        //    ctx.Shipments.Add(shipment);
        //    ctx.SaveChanges();

        //    // ASSERT
        //    Assert.Equal(1, shipment.Id);
        //}

        [Fact]
        public void Fact_PostShipment()
        {
            var shipment = new Shipment(1, 500, 300, 400, 450, "test user");

            // REPOSITORY
            shipment = new ShipmentRepository(ctx).Post(shipment);

            // ASSERT
            Assert.Equal(1, shipment.Id);
        }
        #endregion
    }
}
