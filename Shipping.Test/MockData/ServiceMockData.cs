using Shipping.Infra.Models;

namespace Shipping.Test.MockData
{
    public class ServiceMockData
    {
        public static Service NewService()
        {
            return new Service()
            {
                Id = 1,
                Name = "fedexAir",
                ProviderId = 1
            };
        }
    }
}
