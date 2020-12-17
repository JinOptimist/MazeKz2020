using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Account
{
    public class ProfileViewModel
    {
        public long Id { get; set; }
        public string Login { get; set; }
        public string AvatarUrl { get; set; }
        
        public IFormFile Avatar { get; set; }
    }
}
