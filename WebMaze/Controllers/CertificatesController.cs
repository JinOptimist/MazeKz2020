using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.UserAccount;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Account;
using WebMaze.Models.Certificates;
using System.Net.Http;
using System.Resources;
using Newtonsoft.Json;
using WebMaze.Services;

namespace WebMaze.Controllers
{
    public class CertificatesController : Controller
    {
        private readonly CertificateService certificateService;

        public CertificatesController(CertificateService certificateService)
        {
            this.certificateService = certificateService;
        }

        public async Task<IActionResult> Index()
        {
            var certificateList = await certificateService.GetCertificatesAsync();

            return View(certificateList);
        }

        public ViewResult Get()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Get(long id)
        {
            var certificateViewModel = await certificateService.GetCertificateAsync(id);

            return View(certificateViewModel);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CertificateViewModel certificate)
        {
            var certificateViewModel = await certificateService.CreateCertificateAsync(certificate);

            return View(certificateViewModel);
        }

        public async Task<IActionResult> Update(long id)
        {
            var certificateViewModel = await certificateService.GetCertificateAsync(id);

            return View(certificateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CertificateViewModel certificateViewModel)
        {
            await certificateService.UpdateCertificateAsync(certificateViewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            await certificateService.DeleteCertificateAsync(id);

            return RedirectToAction("Index");
        }
    }
}
