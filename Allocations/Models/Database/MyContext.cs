using Microsoft.EntityFrameworkCore;

namespace Allocations.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbcontextOptions options) {}

        public DbSet<User> Users {get; set;}
    }
}