using RZQ82V_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZQ82V_HFT_2022231.Repository
{
    public class AirPortRepository : Repository<AirPort>, IRepository<AirPort>
    {
        public AirPortRepository(FlyingDbContext ctx) : base(ctx)
        {

        }

        public override AirPort Read(int id)
        {
            return ctx.AirPorts.FirstOrDefault(t => t.AirPortId == id);
        }

        public override void Update(AirPort item)
        {
            var old = Read(item.AirPortId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
