using System;
using System.Linq;
using RZQ82V_HFT_2022231.Models;
using RZQ82V_HFT_2022231.Repository;

namespace RZQ82V_HFT_2022231.Logic
{
    public class PlaneLogic : IPlaneLogic
    {
        IRepository<Plane> repo;

        public PlaneLogic(IRepository<Plane> repo)
        {
            this.repo = repo;
        }

        public void Create(Plane item)
        {
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Plane Read(int id)
        {
            var plane = this.repo.Read(id);
            if (plane == null)
            {
                throw new ArgumentException("Plane not exists!");
            }
            return plane;
        }

        public IQueryable<Plane> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Plane item)
        {
            this.repo.Update(item);
        }
    }
}
