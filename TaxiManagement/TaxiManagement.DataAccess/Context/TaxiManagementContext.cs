using TaxiManagement.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaxiManagement.DataAccess.Context
{
    public partial class TaxiManagementContext : DbContext
    {
        public TaxiManagementContext()
        {
        }

        public TaxiManagementContext(DbContextOptions<TaxiManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Depot> Depot { get; set; }
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Driver> Driver { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.HasOne(c => c.Car)
                    .WithMany(d => d.Driver)
                    .HasForeignKey(c => c.CarId)
                    .HasConstraintName("FK_Driver_Car");
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
                entity.HasOne(c => c.Depot)
                    .WithMany(d => d.Car)
                    .HasForeignKey(c => c.DepotId)
                    .HasConstraintName("FK_Car_Depot");
            });

            modelBuilder.Entity<Depot>(entity =>
            {
                entity.Property(e => e.Id).UseIdentityColumn().Metadata
                    .SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);
            });
            
            //base.OnModelCreating(modelBuilder);
        }
    }
}