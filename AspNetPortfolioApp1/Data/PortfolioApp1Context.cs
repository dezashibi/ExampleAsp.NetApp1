using AspNetPortfolioApp1.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetPortfolioApp1.Data;

public class PortfolioApp1Context(DbContextOptions<PortfolioApp1Context> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
}