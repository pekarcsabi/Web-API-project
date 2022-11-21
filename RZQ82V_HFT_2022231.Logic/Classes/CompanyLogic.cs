using System;
using System.Linq;
using RZQ82V_HFT_2022231.Models;
using RZQ82V_HFT_2022231.Repository;


namespace RZQ82V_HFT_2022231.Logic
{
    internal class CompanyLogic : ICompanyLogic
    {
        IRepository<Company> repo;

        public CompanyLogic(IRepository<Company> repo)
        {
            this.repo = repo;
        }

        public void Create(Company item)
        {
            if (item.Name.Length < 240)
            {
                throw new ArgumentException("Company name too long");
            }
            else
            {
                this.repo.Create(item);
            }
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }

        public Company Read(int id)
        {
            var company = this.repo.Read(id);
            if (company == null)
            {
                throw new ArgumentException("Company not exists!");
            }
            else
            {
                return company;
            }
        }

        public IQueryable<Company> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Company item)
        {
            this.repo.Update(item);
        }

        //NON CRUDS
        public double AvgIncome()
        {
            double result = this.repo.ReadAll().Average(x => x.Income);
            if (result <= 0)
            {
                return 0;
            }
            else
            {
                return result;
            }        
        }
    }
}
