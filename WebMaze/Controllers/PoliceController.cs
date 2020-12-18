using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                var itemResult = new PolicemanViewModel() { CitizenUserProfiles = new ProfileViewModel[0], ProfileVM = new ProfileViewModel() };
                return View(itemResult);
            }

            var profile = mapper.Map<ProfileViewModel>(cuRepo.GetUserByName(User.Identity.Name));

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
        public async Task<IActionResult> Login(LoginViewModel user)
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

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            await Authorize(user.Login);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        private async Task Authorize(string login)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
