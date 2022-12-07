using Microsoft.AspNetCore.Mvc;
using Shipping.Infra.Models;
using Shipping.Services.Services;

namespace Shipping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly ILogger<ShipmentController> _logger;
        private readonly IShipmentService _shipmentService;
        private readonly IServiceService _serviceService;
        public ShipmentController(ILogger<ShipmentController> logger, IShipmentService shipmentService, IServiceService serviceService)
        {
            _logger = logger;
            _shipmentService = shipmentService;
            _serviceService = serviceService;
        }

        [HttpPost(Name = "PostShipment")]
        public IActionResult Post([FromBody] Shipment obj)
        {
            var service = _serviceService.FindById(obj.ServiceId);
            if (service == null)
            {
                ModelState.AddModelError("serviceId", "Invalid serviceId");
                return ValidationProblem(ModelState);
            }
            var createdShipment = _shipmentService.Create(obj);
            _logger.LogInformation($"New shipment is added with Id: {createdShipment.Id}");
            return Ok(createdShipment);
        }
    }
}