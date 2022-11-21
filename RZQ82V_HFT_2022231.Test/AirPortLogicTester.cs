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
    public class AirPortLogicTester
    {
        AirPortLogic logic;
        Mock<IRepository<AirPort>> mockPlaneRepo;

        [SetUp]
        public void Init()
        {
            mockPlaneRepo = new Mock<IRepository<AirPort>>();
            mockPlaneRepo.Setup(m => m.ReadAll()).Returns(new List<AirPort>()
            {
                new AirPort("1#TestI#10"),
                new AirPort("2#TestII#20"),
                new AirPort("3#TestIII#30"),
                new AirPort("4#TestIV#40")
            }.AsQueryable());
            logic = new AirPortLogic(mockPlaneRepo.Object);
        }

        [Test]
        public void CreateAirPortTestWithCorrectName()
        {
            var airport = new AirPort("4#TestAirPort#40");

            logic.Create(airport);

            mockPlaneRepo.Verify(r => r.Create(airport), Times.Once);
        }

        [Test]
        public void CreateAirPortTestWithInCorrectName()
        {
            var airport = new AirPort("4#TestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPort" +
                                      "TestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPortTestAirPort" +
                                      "TestAirPortTestAirPortTestAirPortTestAirPortTestAirPort#40");
            try
            {
                logic.Create(airport);
            }
            catch
            {

            }
            mockPlaneRepo.Verify(r => r.Create(airport), Times.Never);
        }
    }
}
