using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;

namespace WebMaze.Models.Roles
{
    public class RoleEditViewModel
    {
        public RoleViewModel Role { get; set; }

        public List<string> MemberLogins { get; set; }

        public List<string> NonMemberLogins { get; set; }
    }
}
