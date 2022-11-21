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
            modelBuilder.Entity<Flight>()
                .HasOne(r => r.Company)
                .WithMany(company => company.Flights)
                .HasForeignKey(r => r.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight>()
                .HasOne(r => r.Plane)
                .WithMany(plane => plane.Flights)
                .HasForeignKey(r => r.PlaneId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight>()
                .HasOne(r => r.AirPort)
                .WithMany(airport => airport.Flights)
                .HasForeignKey(r => r.FromId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight>()
                .HasOne(r => r.AirPort)
                .WithMany(airport => airport.Flights)
                .HasForeignKey(r => r.ToId)
                .OnDelete(DeleteBehavior.Cascade);


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
                    new AirPort("4#Paris#40"),
                    new AirPort("5#Berlin#60"),
                    new AirPort("6#Róma#30"),
                    new AirPort("7#Moszkva#40"),
                    new AirPort("8#Athén#20")
                });
            modelBuilder.Entity<Flight>().HasData(new Flight[]
                {
                    //FlightId#Date*Time#FromID#ToID#CompanyID#PlaneID
                    new Flight("1#2022*12*12#1#2#3#2"),
                    new Flight("2#2012*12*12#3#4#5#3"),
                    new Flight("3#2022*12*12#4#5#4#1"),
                    new Flight("4#2002*12*12#6#7#1#2"),
                    new Flight("5#2022*12*12#8#9#2#4")
                });
        }
    }
}
