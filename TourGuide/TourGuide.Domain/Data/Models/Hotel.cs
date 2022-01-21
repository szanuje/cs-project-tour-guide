using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourGuide.Domain.Data.Models
{
    [Table("hotels")]
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public Double Price { get; set; }
        [ForeignKey("DestinationFK")]
        public Destination Destination { get; set; }
        public int DestinationFK { get; set; }
    }
}
