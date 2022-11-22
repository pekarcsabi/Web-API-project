using RZQ82V_HFT_2022231.Models;
using System.Linq;

namespace RZQ82V_HFT_2022231.Logic
{
    public interface IFlightLogic
    {
        void Create(Flight item);
        void Delete(int id);
        Flight Read(int id);
        IQueryable<Flight> ReadAll();
        void Update(Flight item);
    }
}