using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=.\\SQLEXPRESS03;Database=Company_SD;Trusted_Connection=True;Encrypt=False;");
    }
}