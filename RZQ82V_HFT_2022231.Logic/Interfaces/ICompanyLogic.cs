using RZQ82V_HFT_2022231.Models;
using System.Linq;

namespace RZQ82V_HFT_2022231.Logic
{
    internal interface ICompanyLogic
    {
        void Create(Company item);
        void Delete(int id);
        Company Read(int id);
        IQueryable<Company> ReadAll();
        void Update(Company item);
    }
}