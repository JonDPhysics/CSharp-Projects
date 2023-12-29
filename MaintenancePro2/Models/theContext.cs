using Microsoft.EntityFrameworkCore;

namespace MaintenancePro2.Models
{
    public class theContext : DbContext
    {
        public theContext(DbContextOptions options) : base(options) { }
        public DbSet<Motor> Motors { get; set; }
        public DbSet<MaintenanceItem> Items {get; set;}
        public DbSet<PreformedItem> PerformedItems { get; set; }
    }
}