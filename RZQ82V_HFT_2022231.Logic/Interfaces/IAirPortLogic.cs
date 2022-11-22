using RZQ82V_HFT_2022231.Models;
using System.Linq;

namespace RZQ82V_HFT_2022231.Logic
{
    public interface IAirPortLogic
    {
        void Create(AirPort item);
        void Delete(int id);
        AirPort Read(int id);
        IQueryable<AirPort> ReadAll();
        void Update(AirPort item);
    }
}