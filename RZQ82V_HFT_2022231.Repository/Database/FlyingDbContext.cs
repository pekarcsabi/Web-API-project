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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>(flight => flight
                .HasOne<Company>()
                .WithMany()
                .HasForeignKey(flight => flight.CompanyId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Flight>(flight => flight
                .HasOne<Plane>()
                .WithMany()
                .HasForeignKey(flight => flight.PlaneId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Flight>(flight => flight
                .HasOne<AirPort>()
                .WithMany()
                .HasForeignKey(flight => flight.FromId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Flight>(flight => flight
                .HasOne<AirPort>()
                .WithMany()
                .HasForeignKey(flight => flight.ToId)
                .OnDelete(DeleteBehavior.Cascade));



            modelBuilder.Entity<Plane>().HasData(new Plane[]
                {
                    //ID#Type#NumOfSeats#YearOfCreate
                    new Plane("1#Airbus A300#554#1992"),
                    new Plane("2#Airbus A310#532#1994"),
                    new Plane("3#Airbus A330#231#1999"),
                    new Plane("4#Airbus A340#320#2001")
                });

            modelBuilder.Entity<Company>().HasData(new Company[]
                {
                    //ID#Name#Income#NumOfPlanes
                    new Company("1#easyJet#201#40"),
                    new Company("2#Turkish Airlines#321#40"),
                    new Company("3#WizzAir#543#31"),
                    new Company("4#Flying Emirates#767#130"),
                    new Company("5#RyanAir#222#22")
                });
            modelBuilder.Entity<AirPort>().HasData(new AirPort[]
                {
                    //ID#Location#CapacityOfPlanes
                    new AirPort("1#Budapest#10"),
                    new AirPort("2#Barcelona#20"),
                    new AirPort("3#London#30"),
                    new AirPort("4#Paris#40")
                });
            modelBuilder.Entity<Flight>().HasData(new Flight[]
                {
                    //FlightId#Date*Time#FromID#ToID#CompanyID#PlaneID
                    new Flight("1#2022*12*12#1#2#3#2")
                });
        }
    }
}
