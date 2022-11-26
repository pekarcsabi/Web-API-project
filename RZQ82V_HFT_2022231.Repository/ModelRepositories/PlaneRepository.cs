using RZQ82V_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZQ82V_HFT_2022231.Repository
{
    public class PlaneRepository : Repository<Plane>, IRepository<Plane>
    {
        public PlaneRepository(FlyingDbContext ctx) : base(ctx)
        {

        }

        public override Plane Read(int id)
        {
            return ctx.Planes.FirstOrDefault(t => t.PlaneId == id);
        }

        public override void Update(Plane item)
        {
            var old = Read(item.PlaneId);
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
