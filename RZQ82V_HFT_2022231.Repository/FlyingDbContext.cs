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
                .HasOne(x => x.Company)
                .WithMany(company => company.Flights)
                .HasForeignKey(r => r.CompanyName)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight>()
                .HasOne(y => y.Plane)
                .WithMany(plane => plane.Flights)
                .HasForeignKey(r => r.PlaneType)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight>()
                .HasOne(z => z.AirPort)
                .WithMany(airport => airport.Flights)
                .HasForeignKey(r => r.From)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Flight>()
                .HasOne(j => j.AirPort)
                .WithMany(airport => airport.Flights)
                .HasForeignKey(r => r.To)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plane>().HasData(new Plane[]
                {
                    //Type#NumOfSeats#YearOfCreate
                    new Plane("Airbus A300#554#1992"),
                    new Plane("Airbus A310#532#1994"),
                    new Plane("Airbus A330#231#1999"),
                    new Plane("Airbus A340#320#2001")
                });

            modelBuilder.Entity<Company>().HasData(new Company[]
                {
                    //Name#Income#NumOfPlanes
                    new Company("easyJet#201#40"),
                    new Company("Turkish Airlines#321#40"),
                    new Company("WizzAir#543#31"),
                    new Company("Flying Emirates#767#130"),
                    new Company("RyanAir#222#22")
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
                    //FlightId#Date*Time#From#To#CompanyName#PlaneType
                    new Flight("1#2022*12*12#Budapest#Barcelona#WizzAir#Airbus A310"),
                    new Flight("2#2022*12*13#London#Paris#RyanAir#Airbus A330"),
                    new Flight("3#2022*12*14#Paris#Barcelona#easyJet#Airbus A300"),
                });
        }
    }
}
