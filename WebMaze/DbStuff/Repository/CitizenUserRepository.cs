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

        public CitizenUser FindExistingCitizenUser(string login)
        {
            return dbSet.SingleOrDefault(x => x.Login == login);
        }
        
        public IEnumerable<CitizenUser> GetUserWithHome()
        {
            return dbSet.Where(x => x.Adresses.Count() > 0);
        }

        public CitizenUser GetUserByName(string userName)
        {
            return dbSet.FirstOrDefault(x => x.Login == userName);
        }
    }
}
