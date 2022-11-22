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
using static RZQ82V_HFT_2022231.Logic.FlightLogic;

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
                //Id#Date*Time#FromID#ToID#CompanyID#PlaneID
                new Flight("1#2012*5*12#1#2#1#1"),
                new Flight("2#2022*6*12#3#4#2#2"),
                new Flight("3#2012*7*12#4#5#4#3"),
                new Flight("4#2018*12*12#5#6#4#4")
            }.AsQueryable());
            logic = new FlightLogic(mockPlaneRepo.Object);
        }

        [Test]
        public void FlightNumberPerYearTest()
        {
            var result = logic.FilghtNumberPerYear();

            List<YearInfo> expected = new List<YearInfo>();
            expected.Add(new YearInfo() { Year = 2012, Count = 2 });
            expected.Add(new YearInfo() { Year = 2022, Count = 1 });
            expected.Add(new YearInfo() { Year = 2018, Count = 1 });
            
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void MostPupuarSeasonToTravelTest()
        {
            var result = logic.MostPupuarSeasonToTravel();

            var expected = new SeasonInfo(){ Name = "Summer", Count = 2 };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
