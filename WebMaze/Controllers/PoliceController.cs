using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebMaze.Controllers.CustomAttribute;
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
            return View(new RegistrationViewModel());
        }

        [HttpPost]
        public IActionResult Login(RegistrationViewModel user)
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

        [Route("[controller]/Signup")]
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegistrationViewModel());
        }

        [Route("[controller]/Signup")]
        [HttpPost]
        public IActionResult Register(RegistrationViewModel user)
        {
            var citizenUser = cuRepo.FindExistingCitizenUser(user.Login);
            if (citizenUser == null)
            {
                ModelState.AddModelError("Login", "Данный логин не существует");
            }
            else if (pmRepo.IsUserPoliceman(citizenUser))
            {
                ModelState.AddModelError("", 
                    "Данный аккаунт уже является аккаунтом полицейского. " +
                    "Пожалуйста, войдите в свой аккаунт через меню входа");
            }
            else
            {
                var man = new Policeman() { Confirmed = false, User = citizenUser };
                pmRepo.Save(man);
            }

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            return RedirectToAction("Index", new { profileId = citizenUser.Id });
        }
    }
}
