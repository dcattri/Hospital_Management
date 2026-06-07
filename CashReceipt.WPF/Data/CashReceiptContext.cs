using Microsoft.EntityFrameworkCore;
using CashReceipt.WPF.Models;

namespace CashReceipt.WPF.Data
{
    public class CashReceiptContext : DbContext
    {
        public CashReceiptContext(DbContextOptions<CashReceiptContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Phone).HasMaxLength(50);
            });
        }
    }
}