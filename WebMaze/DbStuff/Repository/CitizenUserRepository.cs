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
    }
}
