using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.repo.Create(item);
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
            return company;
        }

        public IQueryable<Company> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Company item)
        {
            this.repo.Update(item);
        }
    }
}
