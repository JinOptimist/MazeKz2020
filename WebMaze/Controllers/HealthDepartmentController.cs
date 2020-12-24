using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;

namespace WebMaze.Controllers
{
    public class HealthDepartmentController : Controller
    {
        private HealthDepartmentRepository departmentRepository;
        private IMapper mapper;


        public HealthDepartmentController(HealthDepartmentRepository departmentRepository, IMapper mapper)
        {
            this.departmentRepository = departmentRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public IActionResult HealthDepartment()
        {
            return View();
        }
    }
}
