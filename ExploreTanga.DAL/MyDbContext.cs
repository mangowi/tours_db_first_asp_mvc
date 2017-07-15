using System.Data.Entity;

namespace ExploreTanga.DAL
{
    public class MyDbContext : DbContext
    {
        /// <summary>
        /// can escape by either using \\ or using a single @ on begining of Data ""
        /// </summary>
        public MyDbContext()
            : base("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\documents\\Code\\ASPdotNET\\Git\\Tours_DB_First\\Tours_DB_First\\App_Data\\ExploreCalifornia.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework")
        {
        }
       

        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Tour> Tours { get; set; }
    }
}
