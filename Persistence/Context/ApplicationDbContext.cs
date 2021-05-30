using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Set Make  column size to 128
            modelBuilder.Entity<AirCraft>()
                .Property(s => s.Make)
                .HasColumnName("Make")
                .HasMaxLength(128)
                .IsRequired();

            //Set Model  column size to 128
            modelBuilder.Entity<AirCraft>()
                .Property(s => s.Model)
                .HasColumnName("Model")
                .HasMaxLength(128)
                .IsRequired();

            //Set Location  column size to 10
            modelBuilder.Entity<AirCraft>()
                .Property(s => s.Registration)
                .HasColumnName("Registration")
                .HasMaxLength(10)
                .IsRequired();

            //Set Location  column size to 255
            modelBuilder.Entity<AirCraft>()
                .Property(s => s.Location)
                .HasColumnName("Location")
                .HasMaxLength(255)
                .IsRequired();

            //Set Image Name  column size to 255
            modelBuilder.Entity<AirCraft>()
                .Property(s => s.ImageName)
                .HasColumnName("ImageName")
                .HasMaxLength(255)
                .HasDefaultValue("");

            //Set Image path  default value
            modelBuilder.Entity<AirCraft>()
                .Property(s => s.ImagePath)
                .HasColumnName("ImagePath")
                .HasMaxLength(1500)
                .HasDefaultValue("");

            //Set Location  default value
            modelBuilder.Entity<AirCraft>()
                .Property(s => s.IsActive)
                .HasDefaultValue(true);     
            
            modelBuilder.Entity<AirCraft>()
                .Property(s => s.TxnDate)
                .HasDefaultValueSql("GetDate()");


            modelBuilder.Entity<AirCraft>().HasData(
               new AirCraft { Id = 1, Make = "Boeing -1", Model = "777-300ER", Registration = "G-RNAC", Location = "London Gatwick", TxnDate= DateTime.Parse("2021-05-01"), CreatedDate = DateTime.Parse("2021-05-01"), ModifiedDate = DateTime.Parse("2021-05-01"), IsActive =true},
               new AirCraft { Id = 2, Make = "Boeing -2", Model = "737 MAX", Registration = "M-RNAC", Location = "London Heathrow", TxnDate = DateTime.Parse("2021-05-01"), CreatedDate = DateTime.Parse("2021-05-01"), ModifiedDate = DateTime.Parse("2021-05-01"), IsActive = true },
               new AirCraft { Id = 3, Make = "Boeing -3", Model = "KC-767", Registration = "K-RNAC", Location = "Birmingham", TxnDate = DateTime.Parse("2021-05-01"), CreatedDate = DateTime.Parse("2021-05-01"), ModifiedDate = DateTime.Parse("2021-05-01"), IsActive = true },
               new AirCraft { Id = 4, Make = "Boeing -4", Model = "B-17", Registration = "B-RNAC", Location = "Bristol", TxnDate = DateTime.Parse("2021-05-01"), CreatedDate = DateTime.Parse("2021-05-01"), ModifiedDate = DateTime.Parse("2021-05-01"), IsActive = true },
               new AirCraft { Id = 5, Make = "Boeing -5", Model = "Boeing 777X", Registration = "X-RNAC", Location = "York", TxnDate = DateTime.Parse("2021-05-01"), CreatedDate = DateTime.Parse("2021-05-01"), ModifiedDate = DateTime.Parse("2021-05-01"), IsActive = true },
               new AirCraft { Id = 6, Make = "Boeing -6", Model = "Boeing 777-9", Registration = "C-RNAC", Location = "Oxford", TxnDate = DateTime.Parse("2021-05-01"), CreatedDate = DateTime.Parse("2021-05-01"), ModifiedDate = DateTime.Parse("2021-05-01"), IsActive = true }
            );
        }
        public DbSet<AirCraft> AirCrafts { get; set; }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}


