using ContactAppBackend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactAppBackend
{
    public class AppContext: DbContext
    {
        public DbSet<User> Users { get; set; } 
        public DbSet<Contact> Contacts { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            _ = optionsBuilder.UseSqlServer(connectionString: configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
