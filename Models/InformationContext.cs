using Microsoft.EntityFrameworkCore;

namespace Rocket_Elevator_RESTApi.Models
{
    public class InformationContext : DbContext
    {
        public InformationContext(DbContextOptions<InformationContext> options)
            : base(options)
        {
        }

        public DbSet<Elevator> elevators { get; set; }
        public DbSet<Column> columns { get; set; }
        public DbSet<Battery> batteries { get; set; }
    }
}