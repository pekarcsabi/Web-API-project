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
    [Route("api/[controller]")]
    [ApiController]
    public class PlaneController : ControllerBase
    {
        IPlaneLogic logic;

        public PlaneController(IPlaneLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Plane> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Plane Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Plane value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Plane value)
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
