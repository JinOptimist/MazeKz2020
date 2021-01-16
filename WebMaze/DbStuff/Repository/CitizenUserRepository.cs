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

        public CitizenUser GetUserByName(string userName)
        {
            return dbSet.FirstOrDefault(x => x.Login == userName);
        }

        public CitizenUser GetUserByNameAndPassword(string userName, string password)
        {
            return dbSet.SingleOrDefault(x => x.Login == userName && x.Password == password);
        }

        public CitizenUser GetUserByPassword(string password)
        {
            return dbSet.SingleOrDefault(x => x.Password == password);
        }
    }
}
