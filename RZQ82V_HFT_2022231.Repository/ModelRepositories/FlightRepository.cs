using RZQ82V_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RZQ82V_HFT_2022231.Repository
{
    public class FlightRepository : Repository<Flight>, IRepository<Flight>
    {
        public FlightRepository(FlyingDbContext ctx) : base(ctx)
        {

        }

        public override Flight Read(int id)
        {
            return ctx.Flights.FirstOrDefault(t => t.FlightId == id);
        }

        public override void Update(Flight item)
        {
            var old = Read(item.FlightId);
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
