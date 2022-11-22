using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RZQ82V_HFT_2022231.Logic;
using RZQ82V_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZQ82V_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        ICompanyLogic logic;

        public CompanyController(ICompanyLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Company> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Company Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Company value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Update([FromBody] Company value)
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
