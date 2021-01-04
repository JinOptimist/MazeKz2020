using System;
using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model.Police;

namespace WebMaze.DbStuff.Repository
{
    public class CertificateRepository : BaseRepository<Certificate>
    {
        public CertificateRepository(WebMazeContext context) : base(context) { }

        public void MakeCertificate(Certificate certificate, string userOwnerLogin)
        {
            context.CitizenUser.SingleOrDefault(c => c.Login == userOwnerLogin).Certificates.Add(certificate);
            context.SaveChanges();
        }

        public bool HasValidCertificate(string userOwnerLogin, string speciality, out Certificate certificate)
        {
            var result = from cert in context.CitizenUser.SingleOrDefault(c => c.Login == userOwnerLogin).Certificates
                         where cert.Speciality == speciality
                         where cert.Validity == null || (cert.DateOfIssue <= DateTime.Today && cert.Validity >= DateTime.Today)
                         select cert;

            certificate = result.SingleOrDefault();
            return certificate != null;
        }

        public IEnumerable<Certificate> GetCertificates(string userOwnerLogin, string speciality)
        {
            return (from user in context.CitizenUser
                    where user.Login == userOwnerLogin
                    select user)
                   .SingleOrDefault()?.Certificates.Where(cert => cert.Speciality == speciality);
        }

        public IEnumerable<Certificate> GetCertificates(string userOwnerLogin)
        {
            return (from user in context.CitizenUser
                    where user.Login == userOwnerLogin
                    select user)
                   .SingleOrDefault()?.Certificates;
        }

        public IEnumerable<Certificate> GetAllValidCertificates(string userOwnerLogin)
        {
            var user = (from u in context.CitizenUser
                        where u.Login == userOwnerLogin
                        select u)
                    .SingleOrDefault();

            if (user == null)
            {
                return null;
            }

            var result = new List<Certificate>();

            var specialties = user.Certificates.GroupBy(c => c.Speciality);
            foreach (var spec in specialties)
            {
                result.Add(new Certificate()
                {
                    Speciality = spec.Key,
                    DateOfIssue = spec.Min(s => s.DateOfIssue),
                    Validity = spec.Max(s => s.Validity)
                });
            }

            return result;
        }
    }
}
