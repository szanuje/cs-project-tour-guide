using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourGuide.Domain.Data.Models
{
    public abstract class BaseLocation
    {
        [Key]
        public int LocationId { get; set; }
        public string Name { get; set; }
        public int DestinationFK { get; set; }
        [ForeignKey("DestinationFK")]
        public Destination Destination { get; set; }
        public Address Address { get; set; }
    }
}
