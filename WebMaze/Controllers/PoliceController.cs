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
using WebMaze.Models.PoliceCertificate;
using WebMaze.Models.Police;

namespace WebMaze.Controllers
{
    public class PoliceController : Controller
    {
        private readonly IMapper mapper;
        private readonly PolicemanRepository pmRepo;
        private readonly CitizenUserRepository cuRepo;
        private readonly PoliceCertificateRepository certRepo;

        public PoliceController(IMapper mapper,
            PolicemanRepository pmRepo,
            CitizenUserRepository cuRepo, PoliceCertificateRepository certRepo)
        {
            this.mapper = mapper;
            this.pmRepo = pmRepo;
            this.cuRepo = cuRepo;
            this.certRepo = certRepo;
        }

        public IActionResult Index()
        {
            var card = new CardViewModel
            {
                SubTitle = "Внутри системы",
                Title = "Получить сертификат полицейского",
                Description = "У вас есть страсть бороться с преступностью? Тогда вам к нам."
                    + "Отправьте заявку на получение сертификата не выходя из дома!",
                Link = "#",
                LinkText = "Получить сейчас"
            };

            var result = new MainIndexInfoViewModel()
            {
                Cards = new List<CardViewModel> { card }
            };

            return View(result);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }

            return View(new PoliceLoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(PoliceLoginViewModel user)
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

            await AuthorizeUser(user.Login);

            return RedirectToAction("Index");
        }

        // Authorize methods ------------------------------------------------

        [HttpPost]
        [Authorize]
        public IActionResult RegisterPoliceman()
        {
            var userItem = cuRepo.GetUserByName(User.Identity.Name);
            if (userItem == null || pmRepo.IsUserPoliceman(userItem, out _))
            {
                throw new NotImplementedException();
            }

            pmRepo.MakePolicemanFromUser(userItem);
            return RedirectToAction("Account");
        }

        [HttpPost]
        [Authorize]
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

            if (certRepo.HasValidCertificate(User.Identity.Name, "Police", out var certificate))
            {
                result.Validity = certificate.Validity;
                result.DateOfIssue = certificate.DateOfIssue;
            }

            return View(result);
        }

        [Authorize]
        public IActionResult SignUp()
        {
            return View();
        }

        [Authorize]
        public IActionResult Certificate()
        {
            var user = cuRepo.GetUserByName(User.Identity.Name);
            if (!pmRepo.IsUserPoliceman(user, out _))
            {
                pmRepo.MakePolicemanFromUser(user);
            }

            var addmonths = 1;
            var item = new PoliceCertificateViewModel()
            {
                Speciality = "Police",
                Expires = DateTime.Today.AddMonths(addmonths),
                RedirectToController = "Police",
                RedirectToAction = "Account",
                Price = 10
            };

            if (certRepo.HasValidCertificate(User.Identity.Name, "Police", out var certificate))
            {
                if (certificate.Validity == null)
                {
                    return RedirectToAction("Account");
                }

                item.Starts = certificate.Validity.GetValueOrDefault();
                if (item.Expires != null)
                {
                    item.Expires = item.Starts.AddMonths(addmonths);
                }
            }

            return RedirectToAction("Index", "PoliceCertificate", item);
        }

        // Private methods ----------------------------------------------------

        private async Task AuthorizeUser(string login)
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
