using Microsoft.AspNetCore.Mvc;
using RZQ82V_HFT_2022231.Logic;
using RZQ82V_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RZQ82V_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AirPortNonCrudController : ControllerBase
    {
        IAirPortLogic logic;

        public AirPortNonCrudController(IAirPortLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<AirPortNonCrudController>
        [HttpGet]
        public AirPort LargestAirPort()
        {
            return this.logic.LargestAirPort();
        }
    }
}
