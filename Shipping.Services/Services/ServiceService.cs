using Shipping.Infra.Models;
using Shipping.Infra.Repositories;

namespace Shipping.Services.Services
{
    public class ServiceService: IServiceService
    {
        private readonly IServiceRepository _ServiceRepository;
        public ServiceService(IServiceRepository ServiceRepository)
        {
            _ServiceRepository = ServiceRepository;
        }

        public Service FindById(int id)
        {
            return _ServiceRepository.FindById(id);
        }
    }
}
