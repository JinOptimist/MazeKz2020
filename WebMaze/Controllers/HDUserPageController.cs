using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.HealthDepartment;
using WebMaze.Services;

namespace WebMaze.Controllers
{
    public class HDUserPageController : Controller
    {
        private IMapper mapper;
        private CitizenUserRepository citizenRepository;
        private UserService userService;


        public HDUserPageController(IMapper mapper, CitizenUserRepository citizenRepository, UserService userService)
        {
            this.mapper = mapper;
            this.citizenRepository = citizenRepository;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult UserPage()
        {
            var user = userService.GetCurrentUser();
            var viewModel = mapper.Map<UserPageViewModel>(user);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UserPage(UserPageViewModel viewModel)
        {
            //var citizen = insuranceRepository.Get(id);
            //var model = mapper.Map<UserPageViewModel>(citizen);
            return View(viewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetThisUserInsurance()
        {
            //var insurance = InsuranceService.GetCurrentUserInsurance();
            //var viewModel = mapper.Map<UserPageViewModel>(insurance);

            return PartialView(/*viewModel*/"GetThisUserInsurance");
        }
    }
}
