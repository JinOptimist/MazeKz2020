using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;
using WebMaze.Services;

namespace WebMaze.DbStuff
{
    public static class SeedExtension
    {
        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                AddIfNotExistRoles(scope);
                AddIfNotExistAdmins(scope);

                var webHostEnvironment = scope.ServiceProvider.GetService<IWebHostEnvironment>();

                if (webHostEnvironment.IsDevelopment())
                {
                    new TestDataSeeder(scope).SeedData();
                }
            }

            return host;
        }

        private static void AddIfNotExistRoles(IServiceScope scope)
        {
            var roleRepository = scope.ServiceProvider.GetService<RoleRepository>();

            if (roleRepository == null)
            {
                throw new Exception("Cannot get RoleRepository from ServiceProvider.");
            }

            var roleNames = new List<string> { "Admin", "Policeman", "Doctor" };

            foreach (var roleName in roleNames)
            {
                if (!roleRepository.RoleExists(roleName))
                {
                    var newRole = new Role() { Name = roleName };
                    roleRepository.Save(newRole);
                }
            }
        }

        private static void AddIfNotExistAdmins(IServiceScope scope)
        {
            var userService = scope.ServiceProvider.GetService<UserService>();

            if (userService == null)
            {
                throw new Exception("Cannot get UserService from ServiceProvider.");
            }

            var admins = new List<CitizenUser> { 
                new CitizenUser
                {
                    Login = "Bill",
                    Password = "123",
                    Balance = 120000000000,
                    RegistrationDate = new DateTime(2020, 10, 1),
                    LastLoginDate = new DateTime(2020, 10, 1),
                    FirstName = "Bill",
                    LastName = "Gates",
                    Gender = "Male",
                    Email = "BillGates@example.com",
                    PhoneNumber = "0000000000",
                    BirthDate = new DateTime(1955, 10, 28)
                },
                new CitizenUser
                {
                    Login = "Musk",
                    Password = "123",
                    Balance = 200000000000,
                    RegistrationDate = new DateTime(2020, 12, 15),
                    LastLoginDate = new DateTime(2020, 12, 15),
                    FirstName = "Elon",
                    LastName = "Musk",
                    Gender = "Male",
                    Email = "ElonMusk@example.com",
                    PhoneNumber = "1111111111",
                    BirthDate = new DateTime(1971, 7, 28)
                },
                new CitizenUser
                {
                    Login = "Stroustrup",
                    Password = "123",
                    Balance = 5000000,
                    RegistrationDate = new DateTime(2020, 11, 5),
                    LastLoginDate = new DateTime(2020, 11, 5),
                    FirstName = "Bjarne",
                    LastName = "Stroustrup",
                    Gender = "Male",
                    Email = "BjarneStroustrup@example.com",
                    PhoneNumber = "2222222222",
                    BirthDate = new DateTime(1950, 12, 30)
                }, };

            foreach (var admin in admins)
            {
                var adminFromDb = userService.FindByLogin(admin.Login);

                if (adminFromDb == null)
                {
                    userService.Save(admin);
                    userService.AddToRole(admin, "Admin");
                }
            }
        }
    }
}
