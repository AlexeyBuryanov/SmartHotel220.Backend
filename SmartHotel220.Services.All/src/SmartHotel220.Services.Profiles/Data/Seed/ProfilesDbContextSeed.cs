using System.Linq;

namespace SmartHotel220.Services.Profiles.Data.Seed
{
    /// <summary>
    /// Для начального заполнения базы
    /// </summary>
    public class ProfilesDbContextSeed
    {
        public static void Seed(ProfilesDbContext db)
        {
            if (db.Profiles.Any()) {
                return;
            }

            db.Profiles.Add(new Profile {
                UserId = "alexeyburyanov007@gmail.com",
                Alias = "Alex007",
                Loyalty = Loyalty.Platnum
            });

            db.SaveChanges();
        } // Seed
    } // ProfilesDbContextSeed
}