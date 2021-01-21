using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;
using WebMaze.Services;

namespace WebMaze.DbStuff
{
    public static class SeedExtension
    {
        private static readonly List<CitizenUser> users;

        private static readonly List<Role> roles;

        static SeedExtension()
        {
            roles = new List<Role>()
            {
                new Role
                {
                    Name = "Admin"
                },
                new Role
                {
                    Name = "Policeman"
                },
                new Role
                {
                    Name = "Doctor"
                }
            };
            users = new List<CitizenUser>()
            {
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
                    BirthDate = new DateTime(1955, 10, 28),
                    Roles = roles.Where(role => role.Name == "Admin").ToList()
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
                    BirthDate = new DateTime(1971, 7, 28),
                    Roles = roles.Where(role => role.Name == "Admin").ToList()
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
                    BirthDate = new DateTime(1950, 12, 30),
                    Roles = roles.Where(role => role.Name == "Admin").ToList()
                },
                new CitizenUser
                {
                    Login = "Tsoi",
                    Password = "123",
                    Balance = 300000,
                    RegistrationDate = new DateTime(2020, 10, 28),
                    LastLoginDate = new DateTime(2020, 10, 28),
                    FirstName = "Alexey",
                    LastName = "Tsoi",
                    Gender = "Male",
                    Email = "AlexeyTsoi@example.com",
                    PhoneNumber = "3333333333",
                    BirthDate = new DateTime(1977, 4, 2),
                    Roles = roles.Where(role => role.Name == "Doctor").ToList()
                },
                new CitizenUser
                {
                    Login = "Chuck",
                    Password = "123",
                    Balance = 6000000,
                    RegistrationDate = new DateTime(2020, 12, 30),
                    LastLoginDate = new DateTime(2020, 12, 30),
                    FirstName = "Chuck",
                    LastName = "Norris",
                    Gender = "Male",
                    Email = "ChuckNorris@example.com",
                    PhoneNumber = "4444444444",
                    BirthDate = new DateTime(1940, 3, 10),
                    Roles = roles.Where(role => role.Name == "Policeman").ToList()
                },
                new CitizenUser
                {
                    Login = "Ivan",
                    Password = "123",
                    Balance = 1000,
                    RegistrationDate = new DateTime(2021, 1, 12),
                    LastLoginDate = new DateTime(2021, 1, 12),
                    FirstName = "Ivan",
                    LastName = "Sokolov",
                    Gender = "Male",
                    Email = "IvanSokolov@example.com",
                    PhoneNumber = "5555555555",
                    BirthDate = new DateTime(1980, 5, 17)
                },
                new CitizenUser
                {
                    Login = "Anastasia",
                    Password = "123",
                    Balance = 30000,
                    RegistrationDate = new DateTime(2021, 1, 15),
                    LastLoginDate = new DateTime(2021, 1, 15),
                    FirstName = "Anastasia",
                    LastName = "Kuznecova",
                    Gender = "Female",
                    Email = "AnastasiaKuznecova@example.com",
                    PhoneNumber = "66666666",
                    BirthDate = new DateTime(1990, 11, 22)
                },
                new CitizenUser
                {
                    Login = "Arnold",
                    Password = "123",
                    Balance = 0,
                    RegistrationDate = new DateTime(2021, 1, 16),
                    LastLoginDate = new DateTime(2021, 1, 16),
                    FirstName = "Arnold",
                    LastName = "Goldenberg",
                    Gender = "Male",
                    Email = "ArnoldGoldenberg@example.com",
                    PhoneNumber = "77777777",
                    BirthDate = new DateTime(1977, 5, 10)
                },
                new CitizenUser
                {
                    Login = "Aigerim",
                    Password = "123",
                    Balance = 8000,
                    RegistrationDate = new DateTime(2021, 1, 17),
                    LastLoginDate = new DateTime(2021, 1, 17),
                    FirstName = "Aigerim",
                    LastName = "Alieva",
                    Gender = "Female",
                    Email = "AigerimAlieva@example.com",
                    PhoneNumber = "8888888888",
                    BirthDate = new DateTime(1983, 8, 3)
                },
                new CitizenUser
                {
                    Login = "Dias",
                    Password = "123",
                    Balance = 15000,
                    RegistrationDate = new DateTime(2021, 1, 19),
                    LastLoginDate = new DateTime(2021, 1, 19),
                    FirstName = "Dias",
                    LastName = "Karimov",
                    Gender = "Male",
                    Email = "DiasKarimov@example.com",
                    PhoneNumber = "9999999999",
                    BirthDate = new DateTime(2005, 10, 5)
                }
            };
        }

        public static IHost Seed(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var userService = scope.ServiceProvider.GetService<UserService>();
                var roleRepository = scope.ServiceProvider.GetService<RoleRepository>();

                if (userService == null || roleRepository == null)
                {
                    throw new Exception("Cannot get services from ServiceProvider.");
                }

                var currentUsers = userService.GetUsers();

                var adminExists = currentUsers.Any(user => user.Roles.Any(role => role.Name == "Admin"));

                if (currentUsers.Count == 0 || !adminExists)
                {
                    foreach (var role in roles)
                    {
                        roleRepository.Save(role);
                    }

                    foreach (var user in users)
                    {
                        userService.Save(user);
                    }
                }
            }

            return host;
        }
    }
}
