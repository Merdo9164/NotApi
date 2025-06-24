using Microsoft.EntityFrameworkCore;
using NotApi.Domain.Entities;

namespace NotApi.Infrastructure.Data
{
    public class NotDbContext : DbContext
    {
        public NotDbContext(DbContextOptions<NotDbContext> options) : base(options)
        {
        }

        public DbSet<Not> Notlar { get; set; }
    }
}
