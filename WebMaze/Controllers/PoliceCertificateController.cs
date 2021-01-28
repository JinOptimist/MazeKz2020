using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMaze.DbStuff.Model.Police;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.PoliceCertificate;

namespace WebMaze.Controllers
{
    [Authorize(AuthenticationSchemes = Startup.PoliceAuthMethod)]
    public class PoliceCertificateController : Controller
    {
        private readonly IMapper mapper;
        private readonly PoliceCertificateRepository certRepos;

        public PoliceCertificateController(PoliceCertificateRepository certRepos, IMapper mapper)
        {
            this.certRepos = certRepos;
            this.mapper = mapper;
        }

        public IActionResult Index(PoliceCertificateViewModel policeCertificate)
        {
            if (string.IsNullOrEmpty(policeCertificate.Speciality))
            {
                return NotFound();
            }

            return View(policeCertificate);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult MakeCertificate(PoliceCertificateViewModel policeCertificate)
        {
            var certItem = new PoliceCertificate
            {
                Speciality = policeCertificate.Speciality,
                DateOfIssue = policeCertificate.Starts,
                Validity = policeCertificate.Expires
            };

            certRepos.MakeCertificate(certItem, User.Identity.Name);

            return RedirectToAction(policeCertificate.RedirectToAction, policeCertificate.RedirectToController);
        }

        public IActionResult Items()
        {
            var items = mapper.Map<PoliceCertificateItemViewModel[]>(certRepos.GetAllValidCertificates(User.Identity.Name));
            return View(items);
        }

        public IActionResult History(string speciality)
        {
            PoliceCertificateItemViewModel[] items;
            if (!string.IsNullOrEmpty(speciality))
            {
                items = mapper.Map<PoliceCertificateItemViewModel[]>(certRepos.GetCertificates(User.Identity.Name, speciality));
            }
            else
            {
                items = mapper.Map<PoliceCertificateItemViewModel[]>(certRepos.GetCertificates(User.Identity.Name));
            }

            return View("Items", items);
        }
    }
}
