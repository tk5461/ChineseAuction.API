using System;
using ChineseAuctionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChineseAuctionAPI.Data
{
    public class SalesContextDB : DbContext
    {
    public SalesContextDB(DbContextOptions<SalesContextDB> options) : base(options) { }

    public DbSet<Buyers> Buyers { get; set; }
    public DbSet<Donors> Donors { get; set; }
    public DbSet<gifts> gifts { get; set; }
    public DbSet<Gifts_Orders> Gifts_Orders { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Packages> Packages { get; set; }

        }
    }
