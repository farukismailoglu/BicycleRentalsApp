using BicyleRentalsApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BicyleRentalsApp.Data
{
    public class BicycleRentalsAppDbContext :DbContext
    {
        public BicycleRentalsAppDbContext()
        {

        }
        public BicycleRentalsAppDbContext(DbContextOptions<BicycleRentalsAppDbContext> options)
            :base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<LocationEntity> Locations { get; set; }
        public virtual DbSet<StationEntity> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
                return;

            optionsBuilder.UseSqlServer(@"Server=.;Database=bicyclerentalsappdb;Trusted_Connection=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //User table
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<LocationEntity>().ToTable("locations");
            modelBuilder.Entity<StationEntity>().ToTable("stations");

            modelBuilder.Entity<User>().HasKey(u => u.Id);

            modelBuilder.Entity<User>(u => {
                u.Property(u => u.Id).HasColumnName("user_id");
                u.Property(u => u.Password).HasColumnName("password");
                u.Property(u => u.Score).HasColumnName("score");
                u.Property(u => u.UserName).HasColumnName("user_name");
                u.Property(u => u.CreatedDatetime).HasColumnName("created_datetime");
            });

            //Location Table
            
            modelBuilder.Entity<LocationEntity>().HasKey(l => l.Id);

            modelBuilder.Entity<LocationEntity>(l => {
                l.Property(l => l.Id).HasColumnName("location_id");
                l.Property(l => l.City).HasColumnName("city");
                l.Property(l => l.Country).HasColumnName("country");
                l.Property(l => l.Latitude).HasColumnName("latitude");
                l.Property(l => l.Longitude).HasColumnName("longitude");
            });

            //Station Table

            modelBuilder.Entity<StationEntity>().HasKey(s => s.Id);
            modelBuilder.Entity<StationEntity>(s => {
                s.Property(s => s.Id).HasColumnName("station_id");
                s.Property(s => s.Name).HasColumnName("name");
                s.Property(s => s.EmptySlots).HasColumnName("empty_slots");
                s.Property(s => s.FreeBikes).HasColumnName("free_bikes");
                s.Property(s => s.LocationId).HasColumnName("location_id");
                s.HasOne(d => d.Locations)
                 .WithMany(p => p.Stations)
                 .HasForeignKey(d => d.LocationId);
            });

        }
    }
}
