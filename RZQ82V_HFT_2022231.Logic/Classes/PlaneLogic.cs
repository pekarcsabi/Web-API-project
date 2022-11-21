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
            if (item.Type.Length > 240)
            {
                throw new ArgumentException("Type too long");
            }
            else if (item.NumOfSeats < 2 || item.NumOfSeats > 600)
            {
                throw new ArgumentException("Incorrect number of seats");
            }
            else
            {
                this.repo.Create(item);
            }
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
            else
            {
                return plane;
            }
        }

        public IQueryable<Plane> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Plane item)
        {
            this.repo.Update(item);
        }

        //NON CURDS

        public int Age (int id)
        {
            int result = DateTime.Today.Year - this.repo.Read(id).YearOfCreate;
            if (result < 0)
            {
                return 0;
            }
            else
            {
                return result;
            }
        }
    }
}
