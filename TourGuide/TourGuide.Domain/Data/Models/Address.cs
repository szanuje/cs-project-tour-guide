using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TourGuide.Domain.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public int HouseNumber { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public int BaseLocationFK { get; set; }
        [ForeignKey("BaseLocationFK")]
        public BaseLocation BaseLocation { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, {1}, {2}, {3}, {4} ", Country, City, Street, HouseNumber, PostalCode);
        }
    }
}
