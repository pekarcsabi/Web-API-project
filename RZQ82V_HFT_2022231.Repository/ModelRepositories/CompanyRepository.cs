using RZQ82V_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZQ82V_HFT_2022231.Repository
{
    public class CompanyRepository : Repository<Company>, IRepository<Company>
    {
        public CompanyRepository(FlyingDbContext ctx) : base(ctx)
        {

        }

        public override Company Read(int id)
        {
            return ctx.Companies.FirstOrDefault(t => t.CompanyId == id);
        }

        public override void Update(Company item)
        {
            var old = Read(item.CompanyId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
