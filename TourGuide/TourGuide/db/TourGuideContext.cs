using Microsoft.EntityFrameworkCore;
using TourGuide.models;

namespace TourGuide.db
{
    public class TourGuideContext : DbContext
    {
        public string DbPath { get; }
        public TourGuideContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "tourguide.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseInMemoryDatabase($"Data Source={DbPath}");

        public DbSet<User> Users { get; set; }
    }
}
