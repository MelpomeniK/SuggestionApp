using Microsoft.EntityFrameworkCore;
using SuggestionApp.Models;
using SuggestionApp.DTO;


namespace SuggestionApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
    }
}

