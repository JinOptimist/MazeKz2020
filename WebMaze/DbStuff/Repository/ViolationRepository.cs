using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Police;
using WebMaze.Models.Police.Violation;

namespace WebMaze.DbStuff.Repository
{
    public class ViolationRepository : BaseRepository<Violation>
    {
        public ViolationRepository(WebMazeContext context) : base(context) { }

        public bool AddViolation(Violation item, string userLogin, string policemanLogin)
        {
            item.User = context.CitizenUser.SingleOrDefault(u => u.Login == userLogin);
            item.BlamingPoliceman = context.Policemen.SingleOrDefault(u => u.User.Login == policemanLogin);

            if (item.User == null || item.BlamingPoliceman == null)
            {
                return false;
            }

            Save(item);
            return true;
        }

        public Violation[] GetByGivenSettings(string searchword, DateTime? dateFrom, DateTime? dateTo,
            WayOfOrder orderWay, out int foundTotal, int currentPage = 0, int pageMax = 50)
        {
            var result = from v in dbSet
                         where (string.IsNullOrEmpty(searchword) || (v.User.FirstName + " " + v.User.LastName).Contains(searchword)
                         || (v.BlamingPoliceman.User.FirstName + " " + v.BlamingPoliceman.User.LastName).Contains(searchword))
                         where (dateFrom == null || v.Date >= dateFrom) && (dateTo == null || v.Date <= dateTo)
                         select v;

            result = orderWay switch
            {
                WayOfOrder.Latest => result.OrderByDescending(v => v.Date),
                WayOfOrder.Earliest => result.OrderBy(v => v.Date),
                WayOfOrder.ABCUser => result.OrderBy(v => v.User.FirstName + " " + v.User.LastName),
                WayOfOrder.ABCPolice => result.OrderBy(v => v.BlamingPoliceman.User.FirstName + " " + v.BlamingPoliceman.User.LastName),
                _ => throw new NotImplementedException(),
            };

            var skip = currentPage * pageMax;
            foundTotal = result.Count();
            return result.Skip(skip).Take(pageMax).ToArray();
        }
    }
}
