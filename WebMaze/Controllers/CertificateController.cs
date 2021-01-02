using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.Police;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Certificate;

namespace WebMaze.Controllers
{
    public class CertificateController : Controller
    {
        private readonly CertificateRepository certRepos;

        public CertificateController(CertificateRepository certRepos)
        {
            this.certRepos = certRepos;
        }

        [Authorize]
        public IActionResult Index(CertificateViewModel certificate)
        {
            if (string.IsNullOrEmpty(certificate.Speciality))
            {
                return NotFound();
            }

            return View(certificate);
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult MakeCertificate(CertificateViewModel certificate)
        {
            var certItem = new Certificate
            {
                Speciality = certificate.Speciality,
                DateOfIssue = certificate.Starts,
                Validity = certificate.Expires
            };

            if (certRepos.HasValidCertificate(User.Identity.Name, certificate.Speciality, out var certificate1))
            {
                if (certificate1 != null)
                {
                    certificate1.Validity = certItem.Validity;
                }

                certRepos.Save(certificate1);
            }
            else
            {
                certRepos.MakeCertificate(certItem, User.Identity.Name);
            }

            return RedirectToAction(certificate.RedirectToAction, certificate.RedirectToController);
        }
    }
}
