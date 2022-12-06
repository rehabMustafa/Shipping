
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Shipping.Infra.Models
{
    public class Shipment
    {
        public Shipment()
        {

        }

        public Shipment(int ServiceId, decimal Width, decimal Height, decimal Weight, decimal Length, string CreatedBy)
        {
            this.ServiceId = ServiceId;
            this.Width = Width;
            this.Height = Height;
            this.Weight = Weight;
            this.Length = Length;
            this.CreatedBy = CreatedBy;
        }

        public int Id { get; set; }
        public int ServiceId { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public string CreatedBy { get; set; }

        [ForeignKey("ServiceId")]
        [InverseProperty("Shipments")]
        [IgnoreDataMember]
        public Service? Service { get; set; }
    }
}
