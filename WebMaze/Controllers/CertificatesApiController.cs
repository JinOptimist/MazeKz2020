using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        public async Task<ActionResult<IEnumerable<CertificateViewModel>>> GetCertificates()
        {
            var certificates = await certificateRepository.GetAllAsync();
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

            var citizenUser = citizenUserRepository.GetUserByName(certificateViewModel.OwnerLogin);
            
            if (citizenUser == null)
            {
                return NotFound($"CitizenUser with Login = {certificateViewModel.OwnerLogin} not found");
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
            if (id != certificateViewModel.Id)
            {
                return BadRequest("Certificate ID mismatch");
            }

            if (!await certificateRepository.Exists(id))
            {
                return NotFound($"Certificate with ID = {id} not found");
            }

            var certificate = mapper.Map<Certificate>(certificateViewModel);
            await certificateRepository.SaveAsync(certificate);

            return NoContent();
        }

        // DELETE: api/certificates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(long id)
        {
            if (!await certificateRepository.Exists(id))
            {
                return NotFound($"Certificate with ID = {id} not found");
            }

            await certificateRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
