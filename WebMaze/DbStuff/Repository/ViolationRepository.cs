using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Police;

namespace WebMaze.DbStuff.Repository
{
    public class ViolationRepository : BaseRepository<Violation>
    {
        public ViolationRepository(WebMazeContext context) : base(context) { }

        public bool AddViolation(Violation item, string userLogin, string policemanLogin)
        {
            item.User = context.CitizenUser.SingleOrDefault(u => u.Login == userLogin);
            item.BlamingPoliceman = context.Policemen.SingleOrDefault(u => u.User.Login == policemanLogin);

            if(item.User == null || item.BlamingPoliceman == null)
            {
                return false;
            }

            Save(item);
            return true;
        }
    }
}
