using System;
using System.Linq;
using RZQ82V_HFT_2022231.Repository;
using RZQ82V_HFT_2022231.Models;

namespace RZQ82V_HFT_2022231.Logic
{
    public class FlightLogic : IFlightLogic
    {
        IRepository<Flight> repo;

        public FlightLogic(IRepository<Flight> repo)
        {
            this.repo = repo;
        }

        public void Create(Flight item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Flight Read(int id)
        {
            var flight = repo.Read(id);
            if (flight == null)
            {
                throw new ArgumentException("Flight not exists!");
            }
            else
            {
                return flight;
            }
        }

        public IQueryable<Flight> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Flight item)
        {
            repo.Update(item);
        }

        //NON CRUDS
        public IQueryable FilghtNumberPerYear()
        {
            var flights = repo.ReadAll();

            var result = from x in flights
                         group x by x.When.Year into g
                         select new YearInfo()
                         {
                             Year = g.Key,
                             Count = g.Count()
                         };

            return result;
        }
        public class YearInfo
        {
            public int Year { get; set; }
            public int Count { get; set; }
        }
    }
}
