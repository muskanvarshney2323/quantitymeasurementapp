using Microsoft.EntityFrameworkCore;
using QuantityMeasurementAppModel.Entities;

namespace QuantityMeasurementAppRepositoryLayer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<MeasurementRecord> MeasurementRecords { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MeasurementRecord>(entity =>
            {
                entity.ToTable("MeasurementRecords");

                entity.HasKey(x => x.Id);

                entity.Property(x => x.Operation)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(x => x.Input1Unit).HasMaxLength(25);
                entity.Property(x => x.Input1Type).HasMaxLength(25);
                entity.Property(x => x.Input2Unit).HasMaxLength(25);
                entity.Property(x => x.Input2Type).HasMaxLength(25);
                entity.Property(x => x.DesiredUnit).HasMaxLength(25);
                entity.Property(x => x.OriginalUnit).HasMaxLength(25);
                entity.Property(x => x.OriginalType).HasMaxLength(25);
                entity.Property(x => x.OutputUnit).HasMaxLength(25);
                entity.Property(x => x.OutputText).HasMaxLength(255);
            });
        }
    }
}