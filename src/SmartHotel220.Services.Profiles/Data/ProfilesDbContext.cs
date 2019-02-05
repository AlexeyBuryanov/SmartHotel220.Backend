using Microsoft.EntityFrameworkCore;

namespace SmartHotel220.Services.Profiles.Data
{
    public class ProfilesDbContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public ProfilesDbContext(DbContextOptions options) : base(options) { }
    }
}
