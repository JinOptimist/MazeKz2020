using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public async Task<List<CertificateViewModel>> GetCertificatesAsync()
        {
            var responseString = await httpClient.GetStringAsync("");
            var certificateList = JsonConvert.DeserializeObject<List<CertificateViewModel>>(responseString);

            return certificateList;
        }

        public async Task<CertificateViewModel> GetCertificateAsync(long certificateId)
        {
            var responseString = await httpClient.GetStringAsync(certificateId.ToString());
            var certificate = JsonConvert.DeserializeObject<CertificateViewModel>(responseString);

            return certificate;
        }

        public async Task<CertificateViewModel> CreateCertificateAsync(CertificateViewModel certificate)
        {
            var certificateJson = new StringContent(JsonConvert.SerializeObject(certificate), Encoding.UTF8,
                "application/json");
            
            using var httpResponse = await httpClient.PostAsync("", certificateJson);
            
            if (httpResponse.StatusCode != HttpStatusCode.Created)
            {
                // TODO: Tell user that operation is not successful.
                return null;
            }

            var responseString = await httpResponse.Content.ReadAsStringAsync();
            var receivedCertificate = JsonConvert.DeserializeObject<CertificateViewModel>(responseString);

            return receivedCertificate;
        }

        public async Task UpdateCertificateAsync(CertificateViewModel certificate)
        {
            var certificateJson = new StringContent(JsonConvert.SerializeObject(certificate), Encoding.UTF8,
                "application/json");

            using var httpResponse = await httpClient.PutAsync(certificate.Id.ToString(), certificateJson);

            httpResponse.EnsureSuccessStatusCode();
        }

        public async Task DeleteCertificateAsync(long certificateId)
        {
            using var httpResponse = await httpClient.DeleteAsync(certificateId.ToString());

            httpResponse.EnsureSuccessStatusCode();
        }
    }
}
