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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Not>().HasData(
                new Not { Id = 1, Deger = 85, Aciklama = "Matematik sınavı" },
                new Not { Id = 2, Deger = 90, Aciklama = "Fizik sınavı" },
                new Not { Id = 3, Deger = 75, Aciklama = "Kimya sınavı" }
            );
        }
    }
}
