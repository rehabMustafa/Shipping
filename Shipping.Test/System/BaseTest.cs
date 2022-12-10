using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Shipping.Data;

namespace Shipping.Test.System
{
    public class BaseTest
    {
        protected ShippingContext ctx;
        public BaseTest(ShippingContext? ctx = null)
        {
            this.ctx = ctx ?? GetInMemoryDBContext();
        }
        protected ShippingContext GetInMemoryDBContext()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<ShippingContext>();
            var options = builder.UseInMemoryDatabase("test").UseInternalServiceProvider(serviceProvider).Options;

            ShippingContext dbContext = new ShippingContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return dbContext;
        }

        protected void CheckError<T>(AbstractValidator<T> validator, int ErrorCode, T vm)
        {
            var val = validator.Validate(vm);
            Assert.False(val.IsValid);

            if (!val.IsValid)
            {
                bool hasError = val.Errors.Any(a => a.ErrorCode.Equals(ErrorCode.ToString()));
                Assert.True(hasError);
            }
        }
    }
}
