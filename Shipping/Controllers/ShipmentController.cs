using Microsoft.AspNetCore.Mvc;
using Shipping.Infra.Models;
using Shipping.Services.Services;
using System.Net;

namespace Shipping.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShipmentController : ControllerBase
    {
        private readonly ILogger<ShipmentController> _logger;
        private readonly IShipmentService _shipmentService;
        public ShipmentController(ILogger<ShipmentController> logger, IShipmentService shipmentService)
        {
            _logger = logger;
            _shipmentService = shipmentService;
        }

        [HttpPost(Name = "PostShipment")]
        public IActionResult Post([FromBody] Shipment obj)
        {
            var createdShipment = _shipmentService.Create(obj);

            return new JsonResult(createdShipment);
        }
    }
}