using RZQ82V_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;
using static RZQ82V_HFT_2022231.Logic.FlightLogic;

namespace RZQ82V_HFT_2022231.Logic
{
    public interface IFlightLogic
    {
        void Create(Flight item);
        void Delete(int id);
        Flight Read(int id);
        IQueryable<Flight> ReadAll();
        void Update(Flight item);
        List<YearInfo> FilghtNumberPerYear();
        SeasonInfo MostPupuarSeasonToTravel();
    }
}