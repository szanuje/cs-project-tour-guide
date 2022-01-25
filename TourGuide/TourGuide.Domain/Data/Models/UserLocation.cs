namespace TourGuide.Domain.Data.Models
{
    public class UserLocation
    {
        public string Username;
        public User User;
        public int LocationId { get; set; }
        public BaseLocation BaseLocation { get; set; }
    }
}
