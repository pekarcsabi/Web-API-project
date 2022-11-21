using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using RZQ82V_HFT_2022231.Repository;
using RZQ82V_HFT_2022231.Models;
using RZQ82V_HFT_2022231.Logic;
using static RZQ82V_HFT_2022231.Logic.PlaneLogic;

namespace RZQ82V_HFT_2022231.Test
{
    [TestFixture]
    public class PlaneLogicTester
    {
        PlaneLogic logic;
        Mock<IRepository<Plane>> mockPlaneRepo;

        [SetUp]
        public void Init()
        {
            mockPlaneRepo = new Mock<IRepository<Plane>>();
            mockPlaneRepo.Setup(m => m.ReadAll()).Returns(new List<Plane>()
            {
                new Plane("1#TestTypeI#10#2002"),
                new Plane("2#TestTypeII#20#2010"),
                new Plane("3#TestTypeIII#601#2022"),
                new Plane("4#TestTypeIV#100#2012")
            }.AsQueryable());
            mockPlaneRepo.Setup(m => m.Read(It.IsAny<int>())).Returns(new Plane("1#TestTypeIV#100#3012"));
            logic = new PlaneLogic(mockPlaneRepo.Object);
        }

        [Test]
        public void CreatePlaneTestWithInCorrectNumOfSeats()
        {
            var plane = new Plane("5#CorrectNumOfSeats#1000#2012");
            try
            {
                logic.Create(plane);
            }
            catch
            {

            }
            mockPlaneRepo.Verify(r => r.Create(plane), Times.Never);
        }

        [Test]
        public void CreatePlaneTestWithCorrectType()
        {
            var plane = new Plane("5#CorrectType#100#2012");

            logic.Create(plane);

            mockPlaneRepo.Verify(r => r.Create(plane), Times.Once);
        }

        [Test]
        public void CreatePlaneTestWithInCorrectType()
        {
            var plane = new Plane("6#InCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectType" +
                                  "InCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectTypeInCorrectType" +
                                  "#100#2012");
            try
            {
                logic.Create(plane);
            }
            catch
            {

            }     
            mockPlaneRepo.Verify(r => r.Create(plane), Times.Never);
        }

        [Test]
        public void AgePlaneTestIncorrect()
        {
            var result = logic.Age(1);
            
            int expected = 0;

            Assert.That(result, Is.EqualTo(expected));

        }
    }
}
