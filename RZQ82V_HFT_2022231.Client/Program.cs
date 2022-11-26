using ConsoleTools;
using static RZQ82V_HFT_2022231.Logic.FlightLogic;
using RZQ82V_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RZQ82V_HFT_2022231.Client
{
    internal class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            if (entity == "Plane")
            {
                Console.Write("Enter Plane ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Plane Type: ");
                string name = Console.ReadLine();
                Console.Write("Enter Plane's Number Of Seats: ");
                int seats = int.Parse(Console.ReadLine());
                Console.Write("Enter Plane's Year Of Create: ");
                int year = int.Parse(Console.ReadLine());
                var newPlane = new Plane() { PlaneId = id, Name = name, NumOfSeats = seats, YearOfCreate = year };
                rest.Post(newPlane, "plane");
            }
            else if (entity == "Company")
            {
                Console.Write("Enter Company Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Company ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter Company's Income: ");
                int income = int.Parse(Console.ReadLine());
                Console.Write("Enter Company's Nuber Of Planes: ");
                int num = int.Parse(Console.ReadLine());
                var newCompany = new Company() { Name = name, CompanyId = id, Income = income, NumOfPlanes = num };
                rest.Post(newCompany, "company");
            }
            else if (entity == "AirPort")
            {
                Console.Write("Enter AirPort ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Enter AirPort Location: ");
                string location = Console.ReadLine();
                Console.Write("Enter AirPort Capacity: ");
                int cap = int.Parse(Console.ReadLine());
                var newAirPort = new AirPort() { Location = location, CapacityOfPlanes = cap, AirPortId = id };
                rest.Post(newAirPort, "airport");
            }
            else if (entity == "Flight")
            {
                Console.Write("Enter Flight ID: ");
                int flightid = int.Parse(Console.ReadLine());
                Console.Write("Enter Time Of Flight: ");
                DateTime when = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter From ID: ");
                int fid = int.Parse(Console.ReadLine());
                Console.Write("Enter To ID: ");
                int tid = int.Parse(Console.ReadLine());
                Console.Write("Enter Company ID: ");
                int cid = int.Parse(Console.ReadLine());
                Console.Write("Enter Plane ID: ");
                int pid = int.Parse(Console.ReadLine());
                var newFlight = new Flight() { FlightId = flightid, When = when, FromId = fid, ToId = tid, CompanyId = cid, PlaneId = pid };
                rest.Post(newFlight, "flight");
            }
        }
        
        static void List(string entity)
        {
            if (entity == "Plane")
            {
                List<Plane> planes = rest.Get<Plane>("plane");
                foreach (var item in planes)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if (entity == "Company")
            {
                List<Company> companies = rest.Get<Company>("company");
                foreach (var item in companies)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else if (entity == "AirPort")
            {
                List<AirPort> airports = rest.Get<AirPort>("airport");
                foreach (var item in airports)
                {
                    Console.WriteLine(item.Location);
                }
            }
            else if (entity == "Flight")
            {
                List<Flight> flights = rest.Get<Flight>("flight");
                foreach (var item in flights)
                {
                    Console.WriteLine("ID: " + item.FlightId + " When: " + item.When.Date);
                }
            }
            Console.ReadLine();
        }
        
        static void Update(string entity)
        {
            if (entity == "Plane")
            {
                Console.Write("Enter Plane's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Plane one = rest.Get<Plane>(id, "plane");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "plane");
            }
            else if (entity == "Company")
            {
                Console.Write("Enter Company's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Company one = rest.Get<Company>(id, "company");
                Console.Write($"New name [old: {one.Name}]: ");
                string name = Console.ReadLine();
                one.Name = name;
                rest.Put(one, "company");
            }
            else if (entity == "AirPort")
            {
                Console.Write("Enter AirPort's id to update: ");
                int id = int.Parse(Console.ReadLine());
                AirPort one = rest.Get<AirPort>(id, "airport");
                Console.Write($"New name [old: {one.Location}]: ");
                string location = Console.ReadLine();
                one.Location = location;
                rest.Put(one, "airport");
            }
            else if (entity == "Flight")
            {
                Console.Write("Enter Flight's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Flight one = rest.Get<Flight>(id, "flight");
                Console.Write($"New Time [old: {one.When}]: ");
                DateTime when = DateTime.Parse(Console.ReadLine());
                one.When = when;
                rest.Put(one, "flight");
            }
        }
        
        static void Delete(string entity)
        {
            if (entity == "Plane")
            {
                Console.Write("Enter Plane's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "plane");
            }
            else if (entity == "Company")
            {
                Console.Write("Enter Company's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "company");
            }
            else if (entity == "AirPort")
            {
                Console.Write("Enter AirPort's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "airport");
            }
            else if (entity == "Flight")
            {
                Console.Write("Enter Flight's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "flight");
            }
        }
        
        static void Age()
        {
            Console.Write("Enter a Plane id to get the Plane's age: ");
            int id = int.Parse(Console.ReadLine());
            var result = rest.GetSingle<int>($"PlaneNonCrud/Age/{id}");
            Console.WriteLine("Age: " + result);
            Console.ReadLine();
        }

        static void LargestAirPort()
        {
            var result = rest.GetSingle<AirPort>("AirPortNonCrud/LargestAirPort");
            Console.Write("The Largest AirPort: " + result.Location);
            Console.ReadLine();
        }

        static void AverageIncome()
        {
            var result = rest.GetSingle<double>("CompanyNonCrud/AverageIncome");
            Console.WriteLine("Companies Average Income: " + Math.Round(result,2) + "M $");
            Console.ReadLine();
        }

        static void FlightNumberPerYear()
        {
            var result = rest.GetSingle<List<YearInfo>>("FlightNonCrud/FilghtNumberPerYear");
            foreach (var item in result)
            {
                Console.WriteLine("In " + item.Year + ": " + item.Count + "Db");
            }
            Console.ReadLine();
        }

        static void MostPupuarSeasonToTravel()
        {
            var result = rest.GetSingle<SeasonInfo>("FlightNonCrud/MostPupuarSeasonToTravel");
            Console.WriteLine("The Most Popular Seasoon For Traveling: " + result.Name);
            Console.WriteLine("Number Of Flights In This Season: " + result.Count);
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:63610/", "flight");

            var planeQuerries = new ConsoleMenu(args, level: 2)
                .Add("Age Of Plane", () => Age())
                .Add("Exit", ConsoleMenu.Close);

            var airportQuerries = new ConsoleMenu(args, level: 2)
                .Add("Largest AirPort", () => LargestAirPort())
                .Add("Exit", ConsoleMenu.Close);

            var companyQuerries = new ConsoleMenu(args, level: 2)
                .Add("Average Income", () => AverageIncome())
                .Add("Exit", ConsoleMenu.Close);

            var flightQuerries = new ConsoleMenu(args, level: 2)
               .Add("Flight Number In Years", () => FlightNumberPerYear())
               .Add("The Busiest Season", () => MostPupuarSeasonToTravel())
               .Add("Exit", ConsoleMenu.Close);

            var planeSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Plane"))
                .Add("Create", () => Create("Plane"))
                .Add("Update", () => Update("Plane"))
                .Add("Delete", () => Delete("Plane"))
                .Add("Plane Querries", () => planeQuerries.Show())
                .Add("Exit", ConsoleMenu.Close);

            var companySubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Company"))
                .Add("Create", () => Create("Company"))
                .Add("Update", () => Update("Company"))
                .Add("Delete", () => Delete("Company"))
                .Add("Company Querries", () => companyQuerries.Show())
                .Add("Exit", ConsoleMenu.Close);

            var airportSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("AirPort"))
                .Add("Create", () => Create("AirPort"))
                .Add("Update", () => Update("AirPort"))
                .Add("Delete", () => Delete("AirPort"))
                .Add("AirPort Querries", () => airportQuerries.Show())
                .Add("Exit", ConsoleMenu.Close);

            var flightSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Flight"))
                .Add("Create", () => Create("Flight"))
                .Add("Update", () => Update("Flight"))
                .Add("Delete", () => Delete("Flight"))
                .Add("Flight Querries", () => flightQuerries.Show())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Fligths", () => flightSubMenu.Show())
                .Add("Companies", () => companySubMenu.Show())
                .Add("AirPorts", () => airportSubMenu.Show())
                .Add("Planes", () => planeSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
