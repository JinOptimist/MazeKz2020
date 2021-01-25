using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.HDDoctor;
using WebMaze.Services;

namespace WebMaze.Controllers
{
    [Authorize(Roles = "Doctor")]

    public class HDDoctorPageController : Controller
    {
        private IMapper mapper;
        private CitizenUserRepository citizenRepository;
        private UserService userService;


        public HDDoctorPageController(IMapper mapper, CitizenUserRepository citizenRepository, UserService userService)
        {
            this.mapper = mapper;
            this.citizenRepository = citizenRepository;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult DoctorPage()
        {
            var user = userService.GetCurrentUser();
            var viewModel = mapper.Map<DoctorPageViewModel>(user);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult DoctorPage(DoctorPageViewModel viewModel)
        {
            //var citizen = insuranceRepository.Get(id);
            //var model = mapper.Map<UserPageViewModel>(citizen);
            return View(viewModel);
        }

    }
}
