using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RZQ82V_HFT_2022231.Logic.Interfaces;
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
            repo.Create(item);
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
            return airport;
        }

        public IQueryable<AirPort> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(AirPort item)
        {
            repo.Update(item);
        }
    }
}
