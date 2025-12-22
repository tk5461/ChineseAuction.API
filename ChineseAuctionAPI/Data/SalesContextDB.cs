using System;
using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Data
{
    public class SalesContextDB : DbContext
    {
    public SalesContextDB(DbContextOptions<SalesContextDB> options) : base(options) { }
    public DbSet<Card> Cards { get; set; }    
    public DbSet<Donor> Donors { get; set; }    
    public DbSet<Gift> Gifts { get; set; }
    public DbSet<Gift_Order> Gifts_Orders { get; set; }
    public DbSet<Package_Order> PackageOrders { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<winner> Winners { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

         modelBuilder.Entity<Order>()
        .HasIndex(o => o.userId)
        .HasFilter("[Status] = 0") // Status.Draft = 0 לפי enum
        .IsUnique();
        }

    }
}
