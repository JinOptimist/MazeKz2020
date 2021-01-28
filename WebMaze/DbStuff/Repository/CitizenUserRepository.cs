using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class CitizenUserRepository : BaseRepository<CitizenUser>
    {
        public CitizenUserRepository(WebMazeContext context) : base(context) { }

        public IEnumerable<CitizenUser> GetUserWithHome()
        {
            return dbSet.Where(x => x.Adresses.Count() > 0);
        }

        public CitizenUser GetUserByLogin(string userName)
        {
            return dbSet.SingleOrDefault(x => x.Login == userName);
        }

        public CitizenUser GetUserByNameAndPassword(string userName, string password)
        {
            return dbSet.SingleOrDefault(x => x.Login == userName && x.Password == password);
        }

        public CitizenUser GetUserByPassword(string password)
        {
            return dbSet.SingleOrDefault(x => x.Password == password);
        }

        public IEnumerable<CitizenUser> GetFamiliarUserNames(string userName)
        {
            userName = userName.Trim().Replace(" ", string.Empty);
            return from u in dbSet
                   where (u.FirstName + u.LastName).Contains(userName) || u.Login.Contains(userName)
                   select u;
        }
        
    }
}
