using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Police;

namespace WebMaze.DbStuff.Repository
{
    public class PolicemanRepository : BaseRepository<Policeman>
    {
        public PolicemanRepository(WebMazeContext context) : base(context) { }

        public List<CitizenUser> GetPolicemanUsers()
        {
            var items = from u in dbSet
                        select u.User;

            return items.ToList();
        }

        public List<CitizenUser> GetNotPolicemanUsers()
        {
            var items = from u in context.CitizenUser
                        where !dbSet.Select(p => p.User).Contains(u)
                        select u;
            var test = items.ToList();
            return items.ToList();
        }

        public bool IsUserPoliceman(CitizenUser user)
        {
            var item = dbSet.Where(p => p.User == user).SingleOrDefault();
            return item != null;
        }
    }
}
