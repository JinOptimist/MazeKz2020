using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private IMapper mapper;

        public AccountController(CitizenUserRepository citizenUserRepository, IMapper mapper)
        {
            this.citizenUserRepository = citizenUserRepository;
            this.mapper = mapper;
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

        public IActionResult Profile(long id)
        {
            var citizen = citizenUserRepository.Get(id);
            var viewModel = mapper.Map<ProfileViewModel>(citizen);
            return View(viewModel);
        }
    }
}
