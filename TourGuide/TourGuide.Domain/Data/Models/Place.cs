using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourGuide.Domain.Data.Models
{
    public class Place
    {
        public string Description { get; set; }
        [Key]
        public int PostId { get; set; }
        public string Name { get; set; }
        public int DestinationFK { get; set; }
        [ForeignKey("DestinationFK")]
        public Destination Destination { get; set; }
    }
}
