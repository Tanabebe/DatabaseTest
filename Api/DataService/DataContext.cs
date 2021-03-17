using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.DataService
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}