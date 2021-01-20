using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model.Medicine;
using WebMaze.DbStuff.Repository.MedicineRepo;

namespace WebMaze.Services
{
    public class InsuranceService
    {
        private MedicalInsuranceRepository insuranceRepository;
        private IHttpContextAccessor httpContextAccessor;

        public InsuranceService(MedicalInsuranceRepository insuranceRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.insuranceRepository = insuranceRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        public MedicalInsurance GetCurrentUserInsurance()
        {
            var idStr = httpContextAccessor.HttpContext.
                User.Claims.SingleOrDefault(x => x.Type == "Id")?.Value;
            if(string.IsNullOrEmpty(idStr))
            {
                return null;
            }

            var id = int.Parse(idStr);
            var insurance = insuranceRepository.Get(id);

            return insurance;
        }
    }
}
