using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebMaze.DbStuff.Model.Police;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Account;
using WebMaze.Models.Police;

namespace WebMaze.Controllers
{
    public class PoliceController : Controller
    {
        private readonly IMapper mapper;
        private readonly PolicemanRepository pmRepo;
        private readonly CitizenUserRepository cuRepo;

        public PoliceController(IMapper mapper,
            PolicemanRepository pmRepo,
            CitizenUserRepository cuRepo)
        {
            this.mapper = mapper;
            this.pmRepo = pmRepo;
            this.cuRepo = cuRepo;
        }

        public IActionResult Index(int profileId)
        {
            var profile = mapper.Map<ProfileViewModel>(cuRepo.Get(profileId));

            var userItems = pmRepo.GetNotPolicemanUsers();
            var users = mapper.Map<ProfileViewModel[]>(userItems);

            var item = new PolicemanViewModel() { CitizenUserProfiles = users, ProfileVM = profile };

            return View(item);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel user)
        {
            var userItem = cuRepo.FindExistingCitizenUser(user.Login);
            if (userItem == null)
            {
                ModelState.AddModelError("Login", "Данный логин не существует");
            }
            else if (userItem.Password != user.Password)
            {
                ModelState.AddModelError("Password", "Неправильный пароль");
            }
            else if (!pmRepo.IsUserPoliceman(userItem))
            {
                ModelState.AddModelError("", "Данный человек не является полицейским");
            }

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            return RedirectToAction("Index", new { profileId = userItem.Id });
        }

        [HttpGet]
        public IActionResult RegisterPoliceman(int id)
        {
            var citizenUser = cuRepo.Get(id);
            if (citizenUser == null)
            {
                return NotFound();
            }

            if (!pmRepo.IsUserPoliceman(citizenUser))
            {
                var man = new Policeman() { Confirmed = true, User = citizenUser };
                pmRepo.Save(man);
            }

            return RedirectToAction("Index", new { profileId = id });
        }
    }
}
