using Moq;
using NUnit.Framework;
using RZQ82V_HFT_2022231.Models;
using RZQ82V_HFT_2022231.Repository;
using RZQ82V_HFT_2022231.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RZQ82V_HFT_2022231.Logic.CompanyLogic;

namespace RZQ82V_HFT_2022231.Test
{
    [TestFixture]
    public class CompanyLogicTester
    {
        CompanyLogic logic;
        Mock<IRepository<Company>> mockPlaneRepo;

        [SetUp]
        public void Init()
        {
            mockPlaneRepo = new Mock<IRepository<Company>>();
            mockPlaneRepo.Setup(m => m.ReadAll()).Returns(new List<Company>()
            {
                new Company("1#TestCompanyI#500#10"),
                new Company("2#TestCompanyII#600#20"),
                new Company("3#TestCompanyIII#700#30"),
                new Company("4#TestCompanyIV#800#40")
            }.AsQueryable());
            logic = new CompanyLogic(mockPlaneRepo.Object);
        }

        [Test]
        public void CreateCompanyTestWithCorrectName()
        {
            var company = new Company("4#TestCompany#800#40");

            logic.Create(company);

            mockPlaneRepo.Verify(r => r.Create(company), Times.Once);
        }

        [Test]
        public void CreateCompanyTestWithInCorrectName()
        {
            var company = new Company("4#TestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompany" +
                                      "TestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompanyTestCompany" +
                                      "TestCompanyTestCompanyTestCompanyTestCompany#800#40");
            try
            {
                logic.Create(company);
            }
            catch
            {

            }
            mockPlaneRepo.Verify(r => r.Create(company), Times.Never);
        }

        [Test]
        public void AvgIncomeCompanyTest()
        {
            var result = logic.AvgIncome();

            Assert.That(result, Is.EqualTo(650));
        }
    }
}
