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
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            var userItem = cuRepo.GetUserByName(user.Login);
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

        [Authorize]
        public IActionResult Account()
        {
            var userItem = cuRepo.GetUserByName(User.Identity.Name);
            if (userItem == null)
            {
                throw new NotImplementedException();
            }

            if (!pmRepo.IsUserPoliceman(userItem, out Policeman policeItem))
            {
                userItem.AvatarUrl = ChangeNullPhotoToDefault(userItem.AvatarUrl);
                return View(new PolicemanViewModel { ProfileVM = mapper.Map<ProfileViewModel>(userItem) });
            }

            var result = mapper.Map<PolicemanViewModel>(policeItem);
            result.ProfileVM.AvatarUrl = ChangeNullPhotoToDefault(result.ProfileVM.AvatarUrl);

            return View(result);
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
        private static string ChangeNullPhotoToDefault(string urlPathString)
        {
            const string defaultUserLogoPath = "/image/Police/police_default_user_logo.png";
            if (string.IsNullOrEmpty(urlPathString))
            {
                urlPathString = defaultUserLogoPath;
            }

            return urlPathString;
        }
    }
}
