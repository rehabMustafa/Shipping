using Shipping.Infra.Models;

namespace Shipping.Test.MockData
{
    public class ServiceProviderMockData
    {
        public static ServiceProvider NewServiceProvider()
        {
            return new ServiceProvider()
            {
                Id = 1,
                Name = "fedex"
            };
        }
    }
}
