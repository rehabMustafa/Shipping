using Shipping.Data;
using Shipping.Infra.Models;

namespace Shipping.Infra.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly ShippingContext ctx;
        public ServiceRepository(ShippingContext ctx)
        {
            this.ctx = ctx;
        }

        public Service FindById(int id)
        {
            return ctx.Services.FirstOrDefault(x => x.Id == id);
        }
    }
}
