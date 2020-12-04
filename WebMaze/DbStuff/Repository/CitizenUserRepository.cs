using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class CitizenUserRepository : BaseRepository<CitizenUser>
    {
        public CitizenUserRepository(WebMazeContext context) : base(context) { }
    }
}
