using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourGuide.models
{
    [Table("users")]
    public class User
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
