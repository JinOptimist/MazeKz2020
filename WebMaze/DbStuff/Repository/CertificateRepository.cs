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
    }
}
