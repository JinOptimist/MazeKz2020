using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Bus;

namespace WebMaze.Controllers
{
    public class BusController : Controller
    {
        private BusRepository busRepository;
        private BusRouteRepository busRouteRepository;
        private IWebHostEnvironment hostEnvironment;
        private IMapper mapper;

        public BusController(BusRepository busRepository,
            BusRouteRepository busRouteRepository,
            IMapper mapper,
            IWebHostEnvironment hostEnvironment)
        {
            this.busRepository = busRepository;
            this.busRouteRepository = busRouteRepository;
            this.mapper = mapper;
            this.hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(BusViewModel viewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult ManageBus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ManageBus(BusManageViewModel viewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult OrderBus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderBus(BusOrderViewModel viewModel)
        {
            return View();
        }

    }
}
