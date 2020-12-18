using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Medicine;
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


        public HealthDepartmentController(HealthDepartmentRepository departmentRepository, RecordFormRepository recordFormRepository, 
                                          IMapper mapper)
        {
            this.mapper = mapper;
            this.departmentRepository = departmentRepository;
            this.recordFormRepository = recordFormRepository;
        }


        [HttpGet]
        public IActionResult HealthDepartment()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult RecordForm()
        {
            return View();
        }



        [HttpPost]
        public IActionResult RecordForm(RecordFormViewModel viewModel)
        {
            var user = mapper.Map<RecordForm>(viewModel);
            recordFormRepository.Save(user);

            return RedirectToAction("HealthDepartment");
        }

        [HttpGet]
        public IActionResult GetAllForm(long id)
        {
            var record = recordFormRepository.Get(id);
            var viewModel = mapper.Map<ListRecordFormViewModel>(record);
            

            return View(viewModel);
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
        
    }
}
