using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Roles
{
    public class RoleModificationViewModel
    {
        [Required]
        public string RoleName { get; set; }
        public long RoleId { get; set; }
        public string[] LoginsToAdd { get; set; }
        public string[] LoginsToDelete { get; set; }
    }
}
