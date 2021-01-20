using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;

namespace WebMaze.DbStuff
{
    public static class SeedExtention
    {
        public const string AdminUserName = "admin";

        public static IHost Seed(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                var citizenUserRepository = scope.ServiceProvider.GetService<CitizenUserRepository>();
                var user = citizenUserRepository.GetUserByLogin(AdminUserName);
                if (user == null)
                {
                    user = new CitizenUser()
                    {
                        Login = AdminUserName,
                        Password = "123"
                    };

                    citizenUserRepository.Save(user);
                }


            }
            return host;
        }
    }
}
