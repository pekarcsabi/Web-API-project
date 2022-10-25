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
            FlyingDbContext ctx = new FlyingDbContext();
            foreach (var item in ctx.Planes)
            {
                Console.WriteLine(item.Type);
                foreach (var flight in item.Flights)
                {
                    Console.WriteLine("\t" + flight.FlightId + ": " + flight.Company.Name);
                }
            }
            ;
        }
    }
}
