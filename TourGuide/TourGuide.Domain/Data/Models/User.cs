using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourGuide.Domain.Data.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; } = false;
    }
}
