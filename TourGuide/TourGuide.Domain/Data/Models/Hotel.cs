using System.ComponentModel.DataAnnotations.Schema;

namespace TourGuide.Domain.Data.Models
{
    public class Hotel : BaseLocation
    {
        public string Rating { get; set; }
        public Double Price { get; set; }
    }
}
