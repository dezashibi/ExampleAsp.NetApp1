using AspNetPortfolioApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetPortfolioApp1.Data;

public class PortfolioApp1Context(DbContextOptions<PortfolioApp1Context> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>()
            .HasData(new Item { Id = 4, Name = "Microphone", Price = 40, SerialNumberId = 10 });

        modelBuilder.Entity<SerialNumber>()
            .HasData(new SerialNumber { Id = 10, Number = "SN-MIC-001", ItemId = 4 });

        modelBuilder.Entity<Category>()
            .HasData(
            new Category { Id = 1, Name = "Audio Equipment" },
            new Category { Id = 2, Name = "Books" }
            );

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<SerialNumber> SerialNumbers { get; set; }
    public DbSet<Category> Categories { get; set; }
}