using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.UserTasks;

namespace WebMaze.Controllers
{
    public class UserTasksController : Controller
    {
        private UserTaskRepository userTaskRepository;
        private IWebHostEnvironment webHostEnvironment;
        private IMapper mapper;

        public UserTasksController(UserTaskRepository userTaskRepository, IWebHostEnvironment webHostEnvironment, IMapper mapper)
        {
            this.userTaskRepository = userTaskRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var userTasks = userTaskRepository.GetAll();
            var taskViewModels = mapper.Map<List<UserTaskViewModel>>(userTasks);
            return View(taskViewModels);
        }

        [HttpGet]
        public IActionResult Create(long id)
        {
            return View(nameof(Edit), new UserTaskViewModel());
        }

        [HttpGet]
        public IActionResult Edit(long id)
        {
            var userTask = userTaskRepository.Get(id);
            var userTaskViewModel = mapper.Map<UserTaskViewModel>(userTask);
            return View(userTaskViewModel);
        }

        [HttpPost]
        public IActionResult Edit(UserTaskViewModel userTaskViewModel)
        {
            var userTask = mapper.Map<UserTask>(userTaskViewModel);
            userTaskRepository.Save(userTask);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            userTaskRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
