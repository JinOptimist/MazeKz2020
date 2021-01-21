using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Roles;
using WebMaze.Services;

namespace WebMaze.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private RoleRepository roleRepository;
        private UserService userService;
        private IMapper mapper;

        public RolesController(RoleRepository roleRepository, UserService userService, IMapper mapper)
        {
            this.roleRepository = roleRepository;
            this.userService = userService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var roles = roleRepository.GetAll();
            var roleViewModels = mapper.Map<List<RoleViewModel>>(roles);
            return View(roleViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = mapper.Map<Role>(roleViewModel);
                roleRepository.Save(role);
                return RedirectToAction("Index");
            }

            return View(roleViewModel);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var role = roleRepository.Get(id);
            
            if (role != null)
            {
                roleRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError("", $"Role with ID = {id} is not found");
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(long id)
        {
            var role = roleRepository.Get(id);
            var users = userService.GetUsers();
            var members = new List<CitizenUser>();
            var nonMembers = new List<CitizenUser>();

            foreach (var user in users)
            {
                if (userService.IsInRole(user, role.Name))
                {
                    members.Add(user);
                }
                else
                {
                    nonMembers.Add(user);
                }
            }

            var roleViewModel = mapper.Map<RoleViewModel>(role);

            return View(new RoleEditViewModel
            {
                Role = roleViewModel,
                MemberLogins = members.Select(c => c.Login).ToList(),
                NonMemberLogins = nonMembers.Select(c => c.Login).ToList()
            });
        }

        [HttpPost]
        public IActionResult Edit(RoleModificationViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                foreach (var userLogin in model.LoginsToAdd ?? new string[] { })
                {
                    var user = userService.FindByLogin(userLogin);
                    if (user != null)
                    {
                        userService.AddToRole(user, model.RoleName);
                    }
                }

                foreach (var userLogin in model.LoginsToDelete ?? new string[] { })
                {
                    var user = userService.FindByLogin(userLogin);
                    if (user != null)
                    {
                        userService.RemoveFromRole(user, model.RoleName);
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Edit), model.RoleId);
        }
    }
}
