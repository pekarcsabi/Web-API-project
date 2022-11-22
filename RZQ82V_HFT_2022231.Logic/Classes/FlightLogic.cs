using System;
using System.Linq;
using RZQ82V_HFT_2022231.Repository;
using RZQ82V_HFT_2022231.Models;
using System.Collections.Generic;

namespace RZQ82V_HFT_2022231.Logic
{
    public class FlightLogic : IFlightLogic
    {
        IRepository<Flight> repo;

        public FlightLogic(IRepository<Flight> repo)
        {
            this.repo = repo;
        }

        public void Create(Flight item)
        {
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Flight Read(int id)
        {
            var flight = repo.Read(id);
            if (flight == null)
            {
                throw new ArgumentException("Flight not exists!");
            }
            else
            {
                return flight;
            }
        }

        public IQueryable<Flight> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Flight item)
        {
            repo.Update(item);
        }

        //NON CRUDS
        public List<YearInfo> FilghtNumberPerYear()
        {
            var flights = repo.ReadAll();

            var result = from x in flights
                         group x by x.When.Year into g
                         select new YearInfo()
                         {
                             Year = g.Key,
                             Count = g.Count()
                         };

            return result.ToList();
        }

        public SeasonInfo MostPupuarSeasonToTravel()
        {
            var month = from x in this.repo.ReadAll()
                        group x by x.When.Month into g
                        select new MonthInfo()
                        {
                            Month = g.Key,
                            Count = g.Count()
                        };
            List<SeasonInfo> seasons = new List<SeasonInfo>();
            var winter = new SeasonInfo() { Name = "Winter" };
            var spring = new SeasonInfo() { Name = "Spring" };
            var summer = new SeasonInfo() { Name = "Summer" };
            var autumn = new SeasonInfo() { Name = "Autumn" };

            foreach (var item in month)
            {
                if (item.Month == 1 || item.Month == 2 || item.Month == 12)
                {
                    winter.Count += item.Count;
                }
                else if (item.Month == 3 || item.Month == 4 || item.Month == 5)
                {
                    spring.Count += item.Count;
                }
                else if (item.Month == 6 || item.Month == 7 || item.Month == 18)
                {
                    summer.Count += item.Count;
                }
                else
                {
                    autumn.Count += item.Count;
                }
            }
            seasons.Add(winter);
            seasons.Add(spring);
            seasons.Add(summer);
            seasons.Add(autumn);

            var result = seasons.First(x => x.Count == seasons.Max(t => t.Count));

            return result;
        }
        public class SeasonInfo
        {
            public string Name { get; set; }
            public int Count { get; set; }

            public override bool Equals(object obj)
            {
                SeasonInfo b = obj as SeasonInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Count == b.Count && this.Name == b.Name;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Name, this.Count);
            }
        }
        public class MonthInfo
        {
            public int Month { get; set; }
            public int Count { get; set; }

            public override bool Equals(object obj)
            {
                MonthInfo b = obj as MonthInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Count == b.Count && this.Month == b.Month;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Month, this.Count);
            }
        }

        public class YearInfo
        {
            public int Year { get; set; }
            public int Count { get; set; }

            public override bool Equals(object obj)
            {
                YearInfo b = obj as YearInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Count == b.Count && this.Year == b.Year;
                }
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.Year, this.Count);
            }
        }
    }
}
