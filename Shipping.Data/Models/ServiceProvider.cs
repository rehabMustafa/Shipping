
using System.ComponentModel.DataAnnotations.Schema;

namespace Shipping.Infra.Models
{
    public class ServiceProvider
    {
        public ServiceProvider()
        {
            Services = new HashSet<Service>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty("ServiceProvider")]
        public ICollection<Service> Services { get; set; }
    }
}
