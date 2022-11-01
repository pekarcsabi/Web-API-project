using RZQ82V_HFT_2022231.Models;
using System.Linq;

namespace RZQ82V_HFT_2022231.Logic
{
    public interface IPlaneLogic
    {
        void Create(Plane item);
        void Delete(int id);
        Plane Read(int id);
        IQueryable<Plane> ReadAll();
        void Update(Plane item);
    }
}