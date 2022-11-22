using Moq;
using NUnit.Framework;
using RZQ82V_HFT_2022231.Logic;
using RZQ82V_HFT_2022231.Models;
using RZQ82V_HFT_2022231.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZQ82V_HFT_2022231.Test
{
    [TestFixture]
    public class FlightLogicTester
    {
        FlightLogic logic;
        Mock<IRepository<Flight>> mockPlaneRepo;

        [SetUp]
        public void Init()
        {
            mockPlaneRepo = new Mock<IRepository<Flight>>();
            mockPlaneRepo.Setup(m => m.ReadAll()).Returns(new List<Flight>()
            {
                new Flight("1#TestI#10"),
                new Flight("2#TestII#20"),
                new Flight("3#TestIII#30"),
                new Flight("4#TestIV#40")
            }.AsQueryable());
            logic = new FlightLogic(mockPlaneRepo.Object);
        }
    }
}
