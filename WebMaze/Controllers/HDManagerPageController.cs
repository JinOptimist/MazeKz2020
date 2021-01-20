using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Controllers
{
    public class HDManagerPageController : Controller
    {
        private IMapper mapper;

        public HDManagerPageController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult ManagerPage()
        {
            return View();
        }

        //[HttpGet]
        //public IActionResult AddMedicineCertificate()
        //{
        //    return View(new MedicineCertificateViewModel());
        //}

        //[HttpPost]
        //public IActionResult AddMedicineCertificate(MedicineCertificateViewModel viewModel)
        //{
        //    var certificate = mapper.Map<MedicineCertificate>(viewModel);
        //    certificateRepository.Save(certificate);

        //    return View(new MedicineCertificateViewModel());
        //}

        public IActionResult CheckAmountEmployee()
        {
            //Проверка количества сотрудников и запрос новых(окончивших) из школы
            return View();
        }

        public IActionResult CheckSertificateDoctor()
        {
            //Проверка квалификации врача
            return View();
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
