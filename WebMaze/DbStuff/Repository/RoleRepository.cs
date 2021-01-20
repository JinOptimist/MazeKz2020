using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;

namespace WebMaze.DbStuff.Repository
{
    public class RoleRepository : BaseRepository<Role>
    {
        public RoleRepository(WebMazeContext context) : base(context)
        {
        }

        public Role GetRoleByName(string roleName)
        {
            return dbSet.SingleOrDefault(role => role.Name == roleName);
        }
    }
}
