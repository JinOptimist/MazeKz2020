using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebMaze.DbStuff.Model.UserAccount;
using WebMaze.DbStuff.Repository;
using WebMaze.Models.Certificates;

namespace WebMaze.Controllers
{
    [Route("api/certificates")]
    [ApiController]
    public class CertificatesApiController : ControllerBase
    {
        private CertificateRepository certificateRepository;
        private CitizenUserRepository citizenUserRepository;
        private IMapper mapper;

        public CertificatesApiController(CertificateRepository certificateRepository, CitizenUserRepository citizenUserRepository, IMapper mapper)
        {
            this.certificateRepository = certificateRepository;
            this.citizenUserRepository = citizenUserRepository;
            this.mapper = mapper;
        }

        // GET: api/certificates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CertificateViewModel>>> GetCertificates(
            [FromQuery] string certificateName, [FromQuery] string userLogin)
        {
            List<Certificate> certificates;

            if (!string.IsNullOrWhiteSpace(certificateName))
            {
                certificates = await certificateRepository.GetCertificatesByNameAsync(certificateName);
            }
            else if (!string.IsNullOrWhiteSpace(userLogin))
            {
                certificates = await certificateRepository.GetUserCertificatesAsync(userLogin);
            }
            else
            {
                certificates = await certificateRepository.GetAllAsync();
            }

            var certificateViewModels = mapper.Map<List<CertificateViewModel>>(certificates);

            return certificateViewModels;
        }

        // GET: api/certificates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CertificateViewModel>> GetCertificate(long id)
        {
            var certificate = await certificateRepository.GetByIdAsync(id);

            if (certificate == null)
            {
                return NotFound($"Certificate with ID = {id} not found");
            }

            var certificateViewModel = mapper.Map<CertificateViewModel>(certificate);

            return certificateViewModel;
        }

        // POST: api/certificates
        [HttpPost]
        public async Task<ActionResult<CertificateViewModel>> PostCertificate(CertificateViewModel certificateViewModel)
        {
            // Exclude property from binding.
            certificateViewModel.Id = 0;

            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(modelStateEntry => modelStateEntry.Errors.Select(b => b.ErrorMessage)).ToList();
                return BadRequest(errorMessages);
            }

            var citizenUser = citizenUserRepository.GetUserByLogin(certificateViewModel.OwnerLogin);

            if (citizenUser == null)
            {
                var errorMessages = new List<string>() { $"Citizen with Login = {certificateViewModel.OwnerLogin} not found" };
                return BadRequest(errorMessages);
            }

            if (citizenUser.Certificates.Any(c =>
                c.Name == certificateViewModel.Name && c.Status == CertificateStatus.Valid))
            {
                var errorMessages = new List<string>()
                    {$"The citizen {certificateViewModel.OwnerLogin} already has a valid certificate."};
                return BadRequest(errorMessages);
            }

            var certificate = mapper.Map<Certificate>(certificateViewModel);
            certificate.Owner = citizenUser;
            await certificateRepository.SaveAsync(certificate);

            certificateViewModel = mapper.Map<CertificateViewModel>(certificate);

            return CreatedAtAction("GetCertificate", new { id = certificateViewModel.Id }, certificateViewModel);
        }

        // PUT: api/certificates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCertificate(long id, CertificateViewModel certificateViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values.SelectMany(modelStateEntry => modelStateEntry.Errors.Select(b => b.ErrorMessage)).ToList();
                return BadRequest(errorMessages);
            }

            if (id != certificateViewModel.Id)
            {
                var errorMessages = new List<string>() { "Certificate ID mismatch" };
                return BadRequest(errorMessages);
            }

            if (!await certificateRepository.Exists(id))
            {
                var errorMessages = new List<string>() { $"Certificate with ID = {id} not found" };
                return NotFound(errorMessages);
            }

            var citizenUser = citizenUserRepository.GetUserByLogin(certificateViewModel.OwnerLogin);

            if (citizenUser == null)
            {
                var errorMessages = new List<string>() { $"CitizenUser with Login = {certificateViewModel.OwnerLogin} not found" };
                return NotFound(errorMessages);
            }

            var validCertificate = citizenUser.Certificates.SingleOrDefault(c =>
                c.Name == certificateViewModel.Name && c.Status == CertificateStatus.Valid) ?? new Certificate();
            
            // Check if the valid certificate is not the input certificate.
            if (validCertificate.Id != 0 && validCertificate.Id != certificateViewModel.Id)
            {
                var errorMessages = new List<string>()
                    {$"The citizen {certificateViewModel.OwnerLogin} already has a valid certificate."};
                return BadRequest(errorMessages);
            }

            mapper.Map(certificateViewModel, validCertificate);
            validCertificate.Owner = citizenUser;
            await certificateRepository.SaveAsync(validCertificate);

            return NoContent();
        }

        // DELETE: api/certificates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(long id)
        {
            if (!await certificateRepository.Exists(id))
            {
                var errorMessages = new List<string>() { $"Certificate with ID = {id} not found" };
                return NotFound(errorMessages);
            }

            await certificateRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
