using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourGuide.Domain.Data.Models
{
    [Table("places")]
    public class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [ForeignKey("DestinationFK")]
        public Destination Destination { get; set; }
        public int DestinationFK { get; set; }
        [ForeignKey("AddressFK")]
        public Address Address { get; set; }
        public int AddressFK { get; set; }
    }
}
