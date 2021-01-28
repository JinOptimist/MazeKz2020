using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebMaze.DbStuff.Model.UserAccount;
using WebMaze.Models.Certificates;

namespace WebMaze.Services
{
    public class CertificateService
    {
        private readonly HttpClient httpClient;

        public CertificateService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://localhost:44302/api/certificates/");
            this.httpClient = httpClient;
        }

        public async Task<OperationResult> IssueCertificate(string certificateName, string userLogin, string issuedBy,
            string description, TimeSpan validityPeriod)
        {
            var certificate = new CertificateViewModel
            {
                Name = certificateName,
                Description = description,
                IssuedBy = issuedBy,
                IssueDate = DateTime.Now,
                ExpiryDate = DateTime.Now + validityPeriod,
                OwnerLogin = userLogin
            };

            var operationResult = await CreateCertificateAsync(certificate);

            return operationResult;
        }

        public async Task<OperationResult> RevokeCertificate(string certificateName, string userLogin)
        {
            var userCertificates = await GetUserCertificates(userLogin);
            var validCertificate = userCertificates.SingleOrDefault(certificate =>
                certificate.Name == certificateName && certificate.Status == CertificateStatus.Valid);

            if (validCertificate == null)
            {
                return OperationResult.Failed($"User {userLogin} do not have a valid certificate with name = {certificateName}.");
            }

            validCertificate.Status = CertificateStatus.Revoked;
            var operationResult = await UpdateCertificateAsync(validCertificate);

            if (!operationResult.Succeeded)
            {
                return operationResult;
            }

            return OperationResult.Success();
        }

        public async Task<List<CertificateViewModel>> GetCertificatesAsync()
        {
            var responseString = await httpClient.GetStringAsync("");
            var certificates = JsonConvert.DeserializeObject<List<CertificateViewModel>>(responseString);

            return certificates;
        }

        public async Task<List<CertificateViewModel>> GetUserCertificates(string userLogin)
        {
            var responseString = await httpClient.GetStringAsync($"?userLogin={userLogin}");
            var certificates = JsonConvert.DeserializeObject<List<CertificateViewModel>>(responseString);

            return certificates;
        }

        public async Task<List<CertificateViewModel>> GetCertificatesByName(string certificateName)
        {
            var responseString = await httpClient.GetStringAsync($"?certificateName={certificateName}");
            var certificates = JsonConvert.DeserializeObject<List<CertificateViewModel>>(responseString);

            return certificates;
        }

        public async Task<CertificateViewModel> GetCertificateAsync(long certificateId)
        {
            var responseString = await httpClient.GetStringAsync(certificateId.ToString());
            var certificate = JsonConvert.DeserializeObject<CertificateViewModel>(responseString);

            return certificate;
        }

        public async Task<OperationResult> CreateCertificateAsync(CertificateViewModel certificate)
        {
            var certificateJson = new StringContent(JsonConvert.SerializeObject(certificate), Encoding.UTF8,
                "application/json");

            using var httpResponse = await httpClient.PostAsync("", certificateJson);

            if (httpResponse.StatusCode != HttpStatusCode.Created)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var errorMessages = JsonConvert.DeserializeObject<List<string>>(responseString);
                return new OperationResult { Succeeded = false, Errors = errorMessages };
            }

            return OperationResult.Success();
        }

        public async Task<OperationResult> UpdateCertificateAsync(CertificateViewModel certificate)
        {
            var certificateJson = new StringContent(JsonConvert.SerializeObject(certificate), Encoding.UTF8,
                "application/json");

            using var httpResponse = await httpClient.PutAsync(certificate.Id.ToString(), certificateJson);

            if (!httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var errorMessages = JsonConvert.DeserializeObject<List<string>>(responseString);
                return new OperationResult { Succeeded = false, Errors = errorMessages };
            }

            return OperationResult.Success();
        }

        public async Task<OperationResult> DeleteCertificateAsync(long certificateId)
        {
            using var httpResponse = await httpClient.DeleteAsync(certificateId.ToString());

            if (!httpResponse.IsSuccessStatusCode)
            {
                var responseString = await httpResponse.Content.ReadAsStringAsync();
                var errorMessages = JsonConvert.DeserializeObject<List<string>>(responseString);
                return new OperationResult { Succeeded = false, Errors = errorMessages };
            }
            
            return OperationResult.Success();
        }
    }
}
