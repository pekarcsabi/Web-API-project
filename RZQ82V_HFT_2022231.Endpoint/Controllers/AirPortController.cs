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
    [Route("[controller]")]
    [ApiController]
    public class AirPortController : ControllerBase
    {
        IAirPortLogic logic;

        public AirPortController(IAirPortLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<AirPort> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public AirPort Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] AirPort value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] AirPort value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
