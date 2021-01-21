using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Medicine;
using WebMaze.DbStuff.Repository.MedicineRepo;
using WebMaze.Models.HDManager;

namespace WebMaze.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HDManagerPageController : Controller
    {
        private IMapper mapper;
        private MedicineCertificateRepository certificateRepository;

        public HDManagerPageController(IMapper mapper, MedicineCertificateRepository certificateRepository)
        {
            this.mapper = mapper;
            this.certificateRepository = certificateRepository;
        }

        [HttpGet]
        public IActionResult ManagerPage()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMedicineCertificate()
        {
            return View(new MedicineCertificateViewModel());
        }

        [HttpPost]
        public IActionResult AddMedicineCertificate(MedicineCertificateViewModel viewModel)
        {
            var certificate = mapper.Map<MedicineCertificate>(viewModel);
            certificateRepository.Save(certificate);

            return View(new MedicineCertificateViewModel());
        }

        [HttpGet]
        public IActionResult GetAllCertificate()
        {
            var certificate = certificateRepository.GetAll();
            var viewModel = mapper.Map<List<MedicineCertificateViewModel>>(certificate);

            return View(viewModel);
        }

        public IActionResult CheckAmountEmployee()
        {
            //Проверка количества сотрудников и запрос новых(окончивших) из школы
            return View();
        }

        [HttpGet]
        public IActionResult CheckSertificateDoctor()
        {
            var certificate = certificateRepository.GetAll().Where(x => x.DateExpiration == DateTime.Today);
            var viewModel = mapper.Map<List<MedicineCertificateViewModel>>(certificate);

            return View(viewModel);

        }

        public IActionResult RedirectPatients()
        {
            //Перенаправление в поликлинику или морг
            return View();
        }

        public IActionResult CreateHospital()
        {
            //Создание поликлиники при необходимости
            return View();
        }

        public IActionResult CheckVaccinationCitizens()
        {
            //Проверка вакцинации
            return View();
        }

        public IActionResult GrantApplication()
        {
            //Прием заявок на грант и одобрение или отказ
            return View();
        }

    }
}
