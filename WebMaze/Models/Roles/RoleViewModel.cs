using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Roles
{
    public class RoleViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<string> UserLogins { get; set; }
    }
}
