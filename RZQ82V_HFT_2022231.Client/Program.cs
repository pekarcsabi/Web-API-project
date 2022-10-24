using RZQ82V_HFT_2022231.Models;
using RZQ82V_HFT_2022231.Repository;
using System;
using System.Linq;

namespace RZQ82V_HFT_2022231.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //FlyingDbContext ctx = new FlyingDbContext();
            IRepository<Flight> repo = new FlightRepository(new FlyingDbContext());
            var items = repo.ReadAll().ToArray();
            ;
        }
    }
}
