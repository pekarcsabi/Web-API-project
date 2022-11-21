using System;
using System.Linq;
using RZQ82V_HFT_2022231.Models;
using RZQ82V_HFT_2022231.Repository;

namespace RZQ82V_HFT_2022231.Logic
{
    internal class AirPortLogic : IAirPortLogic
    {
        IRepository<AirPort> repo;

        public AirPortLogic(IRepository<AirPort> repo)
        {
            this.repo = repo;
        }

        public void Create(AirPort item)
        {
            if (item.Location.Length > 240)
            {
                throw new ArgumentException("Location name too long");
            }
            else
            {
                repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public AirPort Read(int id)
        {
            var airport = repo.Read(id);
            if (airport == null)
            {
                throw new ArgumentException("Airport not exists!");
            }
            else
            {
                return airport;
            }
        }

        public IQueryable<AirPort> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(AirPort item)
        {
            repo.Update(item);
        }

        //NON CRUDS
        public IQueryable NumOfFlights (DateTime day)
        {
            var result = from x in this.repo.ReadAll()
                         select x.Flights.Count();
            return result;
        }
    }
}
