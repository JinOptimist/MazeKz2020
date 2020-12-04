using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Account;

namespace WebMaze.Controllers
{
    public class AccountController : Controller
    {
        private CitizenUserRepository citizenUserRepository;
        private IWebHostEnvironment hostEnvironment;
        private IMapper mapper;

        public AccountController(CitizenUserRepository citizenUserRepository, 
            IMapper mapper,
            IWebHostEnvironment hostEnvironment)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            var viewModel = new LoginViewModel()
            {
                Login = "Test",
                Password = "Test"
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Registration(LoginViewModel viewModel)
        {
            var user = mapper.Map<CitizenUser>(viewModel);
            citizenUserRepository.Save(user);
            return View();
        }

        [HttpGet]
        public IActionResult Profile(long id)
        {
            var citizen = citizenUserRepository.Get(id);
            var viewModel = mapper.Map<ProfileViewModel>(citizen);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Profile(ProfileViewModel profileViewModel)
        {
            var citizen = mapper.Map<CitizenUser>(profileViewModel);
            citizenUserRepository.Save(citizen);
            return View(profileViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAvatar(ProfileViewModel viewModel)
        {
            var fileName = viewModel.Avatar.FileName;
            var wwwrootPath = hostEnvironment.WebRootPath;
            var path = @$"{wwwrootPath}\image\avatar\{fileName}";
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await viewModel.Avatar.CopyToAsync(fileStream);
            }

            var citizen = citizenUserRepository.Get(viewModel.Id);
            citizen.AvatarUrl = $"/image/avatar/{fileName}";
            citizenUserRepository.Save(citizen);

            return RedirectToAction("Profile", new { id = viewModel.Id });
        }
    }
}
