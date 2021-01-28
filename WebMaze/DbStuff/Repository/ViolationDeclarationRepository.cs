using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Police;
using WebMaze.Models.Police.Violation;

namespace WebMaze.DbStuff.Repository
{
    public class ViolationDeclarationRepository : BaseRepository<ViolationDeclaration>
    {
        public ViolationDeclarationRepository(WebMazeContext context) : base(context) { }

        public bool AddViolationDeclaration(string userLogin, string blamedLogin, ViolationDeclaration item)
        {
            var user = context.CitizenUser.SingleOrDefault(u => u.Login == userLogin);
            var blamed = context.CitizenUser.SingleOrDefault(u => u.Login == blamedLogin);
            if(user == null || blamed == null)
            {
                return false;
            }

            item.Status = "Not Viewed";
            item.User = user;
            item.BlamedUser = blamed;
            
            Save(item);
            return true;
        }
    }
}
