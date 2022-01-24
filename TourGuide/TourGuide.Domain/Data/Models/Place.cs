using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourGuide.Domain.Data.Models
{
    public class Place : BaseLocation
    {
        public string Description { get; set; }
    }
}
