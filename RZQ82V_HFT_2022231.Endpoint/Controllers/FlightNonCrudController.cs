using Microsoft.AspNetCore.Mvc;
using RZQ82V_HFT_2022231.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RZQ82V_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FlightNonCrudController : ControllerBase
    {
        IFlightLogic logic;

        public FlightNonCrudController(IFlightLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public List<FlightLogic.YearInfo> FilghtNumberPerYear()
        {
            return this.logic.FilghtNumberPerYear();
        }

        [HttpGet]
        public FlightLogic.SeasonInfo MostPupuarSeasonToTravel()
        {
            return this.logic.MostPupuarSeasonToTravel();
        }
    }
}
