using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Medicine;
using WebMaze.DbStuff.Repository;
using WebMaze.DbStuff.Repository.MedicineRepo;
using WebMaze.DbStuff.Repository.MedicineRepository;
using WebMaze.Models.Account;
using WebMaze.Models.Department;
using WebMaze.Models.HealthDepartment;

namespace WebMaze.Controllers
{
    public class HealthDepartmentController : Controller
    {
        private HealthDepartmentRepository departmentRepository;
        private RecordFormRepository recordFormRepository;
        private IMapper mapper;
        private CitizenUserRepository citizenRepository;
        private MedicalInsuranceRepository medInsurRepository;



        public HealthDepartmentController(HealthDepartmentRepository departmentRepository, RecordFormRepository recordFormRepository,
                                          IMapper mapper, CitizenUserRepository citizenRepository,
                                          MedicalInsuranceRepository medInsurRepository)
        {
            this.mapper = mapper;
            this.departmentRepository = departmentRepository;
            this.recordFormRepository = recordFormRepository;
            this.citizenRepository = citizenRepository;
            this.medInsurRepository = medInsurRepository;
        }


        [HttpGet]
        public IActionResult HealthDepartment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HealthDepartmentForAuthorized()
        {
            return View();
        }


        [HttpGet]
        public IActionResult RecordForm()
        {
            return PartialView("RecordForm");
        }



        [HttpPost]
        public IActionResult RecordForm(RecordFormViewModel viewModel)
        {
            var user = mapper.Map<RecordForm>(viewModel);
            recordFormRepository.Save(user);

            return RedirectToAction("HealthDepartment");
        }

        [HttpGet]
        public IActionResult GetAllForm()
        {
            var record = recordFormRepository.GetAll();
            var viewModel = mapper.Map<List<ListRecordFormViewModel>>(record);


            return View(viewModel);
        }

        [HttpGet]
        public IActionResult MedicalInsurance()
        {
            return View(new MedicalInsuranceViewModel());
        }

        [HttpPost]
        public IActionResult MedicalInsurance(MedicalInsuranceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var id = viewModel.OwnerId;
            var coast = viewModel.Coast;
            var person = citizenRepository.Get(id);
            var solvency = person.Balance.CompareTo(coast);

            if (solvency >= 0)
            {
                var user = mapper.Map<MedicalInsurance>(viewModel);
                medInsurRepository.Save(user);
            }

            return View();

        }


        [HttpGet]
        public IActionResult GetListHospital()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetListMorgue()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetListSchool()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult HotLine()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MedicineNews()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View(new ForDHLoginViewModel());
        }

        [HttpPost]
        public IActionResult Registration(ForDHLoginViewModel loginView)
        {
            if (!ModelState.IsValid)
            {
                return View(loginView);

            }

            return RedirectToAction("HealthDepartmentForAuthorized");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new ForDHLoginViewModel());
        }

        [HttpPost]
        public IActionResult Login(ForDHLoginViewModel loginView)
        {
            if (!ModelState.IsValid)
            {
                return View(loginView);

            }

            return RedirectToAction("HealthDepartmentForAuthorized");

        }

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

        [HttpGet]
        public IActionResult MyCitizenTest()
        {
            var viewModel = new ForDHLoginViewModel()
            {
                FirstName = "Ivan",
                LastName = "Ivanov",
                Gender = "Male",
                Email = "Ivan@mail.com",
                PhoneNumber = "87778888888",
                IsDead = false,
                Marriage = true,
                HaveChildren = true,
                Balance = 1000000000,
                BirthDate = DateTime.Now,
                Login = "Vano",
                Password = "3333"

            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult MyCitizenTest(ForDHLoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = mapper.Map<CitizenUser>(viewModel);
            citizenRepository.Save(user);
            return View();
        }

        [HttpGet]
        public IActionResult Hospital1()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hospital2()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hospital3()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hospital4()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hospital5()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hospital6()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Hospital7()
        {
            return View();
        }




    }
}
