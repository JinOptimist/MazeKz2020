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

        public IEnumerable<CitizenUser> GetPolicemanUsers()
        {
            var items = from u in dbSet
                        select u.User;

            return items;
        }

        public bool IsUserPoliceman(CitizenUser user, out Policeman output)
        {
            output = dbSet.Where(p => p.User.Login == user.Login).SingleOrDefault();
            return output != null;
        }

        public void MakePolicemanFromUser(CitizenUser user)
        {
            var policeman = new Policeman() { User = user, Rank = "Не имеет сертификат" };
            Save(policeman);
        }
    }
}
