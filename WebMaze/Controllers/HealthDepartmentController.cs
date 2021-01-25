using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
using WebMaze.Services;

namespace WebMaze.Controllers
{
    public class HealthDepartmentController : Controller
    {
        private RecordFormRepository recordFormRepository;
        private IMapper mapper;
        private CitizenUserRepository citizenRepository;
        private MedicalInsuranceRepository insuranceRepository;
        private UserService userService;


        public HealthDepartmentController(RecordFormRepository recordFormRepository,
                                          IMapper mapper, CitizenUserRepository citizenRepository,
                                          MedicalInsuranceRepository insuranceRepository, UserService userService)
        {
            this.mapper = mapper;
            this.recordFormRepository = recordFormRepository;
            this.citizenRepository = citizenRepository;
            this.insuranceRepository = insuranceRepository;
            this.userService = userService;
        }


        [HttpGet]
        public IActionResult HealthDepartment()
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
                insuranceRepository.Save(user);
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

            return RedirectToAction("HealthDepartment");
        }

        [HttpGet]
        public IActionResult Login()
        {
            var viewvModel = new ForDHLoginViewModel();
            viewvModel.ReturnUrl = Request.Query["ReturnUrl"];

            return View(viewvModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(ForDHLoginViewModel loginView)
        {
            var user = citizenRepository.GetUserByNameAndPassword(loginView.Login, loginView.Password);
            if(user == null)
            {
                return View(loginView);
            }

            //var recordId = new Claim("Id", user.Id.ToString());
            //var recordName = new Claim(ClaimTypes.Name, user.Login);
            //var recordAuthMetod = new Claim(ClaimTypes.AuthenticationMethod, Startup.MedicineAuth);

            //var page = new List<Claim>() { recordId, recordName, recordAuthMetod };

            //var claimsIdentity = new ClaimsIdentity(page, Startup.MedicineAuth);

            //var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            //await HttpContext.SignInAsync(claimsPrincipal);

            await userService.SignInAsync(loginView.Login, loginView.Password, isPersistent: false);

            if (string.IsNullOrEmpty(loginView.ReturnUrl))
            {
                return RedirectToAction("HealthDepartment", "HealthDepartment");
            }
            else
            {
                return Redirect(loginView.ReturnUrl);
            }
            
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("HealthDepartment", "HealthDepartment");
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
