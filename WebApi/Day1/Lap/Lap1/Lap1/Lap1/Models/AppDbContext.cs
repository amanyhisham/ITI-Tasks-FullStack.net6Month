using Lap1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lap1.Models
{
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options)
                : base(options)
            {
            }

            public DbSet<Course> Courses { get; set; }
        }
}



 
    
 