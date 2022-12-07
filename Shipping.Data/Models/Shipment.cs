
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Shipping.Infra.Models
{
    public class Shipment
    {
        public Shipment()
        {

        }

        public Shipment(int ServiceId, int Width, int Height, int Weight, int Length,int MeasurementType, string CreatedBy)
        {
            this.ServiceId = ServiceId;
            this.Width = Width;
            this.Height = Height;
            this.Weight = Weight;
            this.Length = Length;
            this.CreatedBy = CreatedBy;
            this.MeasurementType = MeasurementType;
        }

        public int Id { get; set; }
        [Required]
        public int ServiceId { get; set; }
        [Range(1, int.MaxValue)]
        public int Width { get; set; }
        [Range(1, int.MaxValue)]
        public int Height { get; set; }
        [Range(1, int.MaxValue)]
        public int Weight { get; set; }
        [Range(1, int.MaxValue)]
        public int Length { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string CreatedBy { get; set; }
        [Required]
        [Range(0, 1)]
        public int MeasurementType { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ServiceId")]
        [InverseProperty("Shipments")]
        [IgnoreDataMember]
        public Service? Service { get; set; }
    }
}
