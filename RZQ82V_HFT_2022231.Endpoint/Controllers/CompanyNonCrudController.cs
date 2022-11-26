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
    public class CompanyNonCrudController : ControllerBase
    {
        ICompanyLogic logic;

        public CompanyNonCrudController(ICompanyLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public double  AverageIncome()
        {
            return this.logic.AvgIncome();
        }
    }
}
