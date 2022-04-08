using Microsoft.EntityFrameworkCore;

namespace BusBooking.DbContext
{
    public class ApplicationDbContext: Microsoft.EntityFrameworkCore.DbContext 
    {
        public DbSet<Bus> Buses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Integrated Security=True;Database=shashank;");
        }

        

        
    }
}
