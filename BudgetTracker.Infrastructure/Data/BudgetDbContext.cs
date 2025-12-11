using BudgetTracker.Core.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracker.Infrastructure.Data
{
    public class BudgetDbContext : IdentityDbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Konfiguracja Transaction
            builder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transactions");

                entity.Property(e => e.Amount)
                      .HasPrecision(18, 2)
                      .IsRequired();

                entity.Property(e => e.Description)
                      .HasMaxLength(200);

                // Relacja Transaction -> Category
                entity.HasOne(e => e.Category)
                      .WithMany(c => c.Transactions)
                      .HasForeignKey(e => e.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.UserId);
            });

            // Konfiguracja Category
            builder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Name)
                      .IsRequired()
                      .HasMaxLength(50);

                // Domyślny kolor
                entity.Property(e => e.ColorHex)
                      .HasDefaultValue("#000000");
            });
        }
    }
}

