using System.Data.Entity;

namespace ExploreTanga.DAL
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=ExploreTanga")
        {
        }
       

        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
    }
}
