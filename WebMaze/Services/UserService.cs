using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;

namespace WebMaze.Services
{
    public class UserService
    {
        private CitizenUserRepository citizenUserRepository;
        private IHttpContextAccessor httpContextAccessor;

        public UserService(CitizenUserRepository citizenUserRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public CitizenUser GetCurrentUser()
        {
            var idStr = httpContextAccessor.HttpContext.
                User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            if (string.IsNullOrEmpty(idStr))
            {
                return null;
            }

            var id = int.Parse(idStr);
            var citizen = citizenUserRepository.Get(id);
            return citizen;
        }
    }
}
