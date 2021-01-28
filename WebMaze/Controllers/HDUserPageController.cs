using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Medicine;
using WebMaze.DbStuff.Repository;
using WebMaze.DbStuff.Repository.MedicineRepo;
using WebMaze.Models.HealthDepartment;
using WebMaze.Services;

namespace WebMaze.Controllers
{
    [Authorize(Roles = "User")]

    public class HDUserPageController : Controller
    {
        private IMapper mapper;
        private UserService userService;
        private MedicalInsuranceRepository insuranceRepository;
        private ReceptionOfPatientsRepository receptionRepository;


        public HDUserPageController(IMapper mapper, UserService userService,
            MedicalInsuranceRepository insuranceRepository, ReceptionOfPatientsRepository receptionRepository)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.insuranceRepository = insuranceRepository;
            this.receptionRepository = receptionRepository;
        }

        [HttpGet]
        public IActionResult UserPage()
        {
            var user = userService.GetCurrentUser();
            var viewModel = mapper.Map<UserPageViewModel>(user);
            return View(viewModel);
        }


        [HttpGet]
        public IActionResult EditThisUserInsurance()
        {
            var insurance = userService.GetCurrentUser().MedicalInsurance;
            var viewModel = mapper.Map<MedicalInsuranceViewModel>(insurance);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditThisUserInsurance(MedicalInsuranceViewModel viewModel)
        {
            var insurance = mapper.Map<MedicalInsurance>(viewModel);
            insuranceRepository.Save(insurance);

            return RedirectToAction("UserPage");
        }


        [HttpPost]
        public IActionResult EditThisUserDoctorsAppointments(UserPageViewModel viewModel)
        {
            var enrolledCitizen = receptionRepository.Get(viewModel.EnrolledCitizenId);
            var appointment = mapper.Map<ReceptionOfPatients>(viewModel);
            appointment.EnrolledCitizen = enrolledCitizen.EnrolledCitizen;
            receptionRepository.Save(appointment);

            return RedirectToAction("UserPage");
        }

    }
}
