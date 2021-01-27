using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMaze.Models.Certificates;
using WebMaze.Filters;
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

        [ImportModelStateErrorsFromTempData]
        public async Task<IActionResult> Index(string userLogin, string certificateName)
        {
            List<CertificateViewModel> certificates;

            if (!string.IsNullOrWhiteSpace(certificateName))
            {
                certificates = await certificateService.GetCertificatesByName(certificateName);
            }
            else if (!string.IsNullOrWhiteSpace(userLogin))
            {
                certificates = await certificateService.GetUserCertificates(userLogin);
            }
            else
            {
                certificates = await certificateService.GetCertificatesAsync();
            }

            return View(certificates);
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
            if (ModelState.IsValid)
            {
                var operationResult = await certificateService.CreateCertificateAsync(certificate);

                if (!operationResult.Succeeded)
                {
                    foreach (var error in operationResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
            }
            
            return View(certificate);
        }

        [HttpPost]
        [ExportModelStateErrorsToTempData]
        public async Task<IActionResult> Issue(string userLogin)
        {
            var operationResult = await certificateService.IssueCertificate("Birth certificate", userLogin,
                "Government", "Birth certificate", TimeSpan.FromDays(3650));
            
            if (!operationResult.Succeeded)
            {
                foreach (var error in operationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ExportModelStateErrorsToTempData]
        public async Task<IActionResult> Revoke(string certificateName, string userLogin)
        {
            var operationResult = await certificateService.RevokeCertificate(certificateName, userLogin);

            if (!operationResult.Succeeded)
            {
                foreach (var error in operationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(long id)
        {
            var certificateViewModel = await certificateService.GetCertificateAsync(id);

            return View(certificateViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CertificateViewModel certificateViewModel)
        {
            if (ModelState.IsValid)
            {
                var operationResult = await certificateService.UpdateCertificateAsync(certificateViewModel);

                if (!operationResult.Succeeded)
                {
                    foreach (var error in operationResult.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                }
            }

            return View(certificateViewModel);
        }

        [HttpPost]
        [ExportModelStateErrorsToTempData]
        public async Task<IActionResult> Delete(long id)
        {
            var operationResult = await certificateService.DeleteCertificateAsync(id);

            if (!operationResult.Succeeded)
            {
                foreach (var error in operationResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
