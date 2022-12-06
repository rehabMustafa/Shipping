
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Shipping.Infra.Models
{
    public class Service
    {
        public Service()
        {
            Shipments = new HashSet<Shipment>();
        }
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Name { get; set; }

        [ForeignKey("ProviderId")]
        [InverseProperty("Services")]
        [IgnoreDataMember]
        public ServiceProvider ServiceProvider { get; set; }
        [InverseProperty("Service")]
        public ICollection<Shipment> Shipments { get; set; }
    }
}
