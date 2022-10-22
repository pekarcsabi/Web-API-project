using System;
using Microsoft.EntityFrameworkCore;
using RZQ82V_HFT_2022231.Models;

namespace RZQ82V_HFT_2022231.Repository
{
    public class FlyingDbContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<AirPort> AirPorts { get; set; }
        public FlyingDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                .UseInMemoryDatabase("flyingDB")
                .UseLazyLoadingProxies();
            }
        }
    }
}
