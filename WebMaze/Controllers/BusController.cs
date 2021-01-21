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
            var buses = busRepository.GetAll();
            var viewModel = new BusManageViewModel();
            foreach(var bus in buses)
            {
                var model = mapper.Map<BusViewModel>(bus);
                viewModel.Buses.Add(model);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ManageBus(BusManageViewModel viewModel)
        {
            var bus = mapper.Map<Bus>(viewModel);
            busRepository.Save(bus);


            return RedirectToAction("ManageBus","Bus");
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

        [HttpGet]
        public IActionResult CreateBusRoute()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBusRoute(CreateBusRouteViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var busRoute = mapper.Map<BusRoute>(viewModel);
            busRouteRepository.Save(busRoute);
            return View();
        }

        [HttpGet]
        public IActionResult ManageBusRouteTime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ManageBusRouteTime(BusRouteTimeManagmentViewModel viewModel)
        {
            return View();
        }

        [HttpGet]
        public IActionResult ManageWorker()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ManageWorker(BusOrderViewModel viewModel)
        {
            return View();
        }

        public IActionResult BusAdminPartial()
        {
            return PartialView();
        }

        public IActionResult BusUserPartial()
        {
            return PartialView();
        }

    }
}

/*
 
Автобусы. Просмотр доступных маршрутов, работников, транспорта и запрос на склад. Остановка.
Статус автобуса и оповещение стоящих на остановке о том, что автобус переполнен и когда будет доступен следующий. 
Прием заказов на использование автобуса компаниями.
*/