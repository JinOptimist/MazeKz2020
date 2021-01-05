using System;
using System.Collections.Generic;
using System.Linq;
using WebMaze.DbStuff.Model.Police;

namespace WebMaze.DbStuff.Repository
{
    public class PoliceCertificateRepository : BaseRepository<PoliceCertificate>
    {
        public PoliceCertificateRepository(WebMazeContext context) : base(context) { }

        public void MakeCertificate(PoliceCertificate policeCertificate, string userOwnerLogin)
        {
            context.CitizenUser.SingleOrDefault(c => c.Login == userOwnerLogin).PoliceCertificates.Add(policeCertificate);
            context.SaveChanges();
        }

        public bool HasValidCertificate(string userOwnerLogin, string speciality, out PoliceCertificate policeCertificate)
        {
            var result = from cert in context.CitizenUser.SingleOrDefault(c => c.Login == userOwnerLogin).PoliceCertificates
                         where cert.Speciality == speciality
                         where cert.Validity == null || (cert.DateOfIssue <= DateTime.Today && cert.Validity >= DateTime.Today)
                         select cert;

            policeCertificate = result.SingleOrDefault();
            return policeCertificate != null;
        }

        public IEnumerable<PoliceCertificate> GetCertificates(string userOwnerLogin, string speciality)
        {
            return (from user in context.CitizenUser
                    where user.Login == userOwnerLogin
                    select user)
                   .SingleOrDefault()?.PoliceCertificates.Where(cert => cert.Speciality == speciality);
        }

        public IEnumerable<PoliceCertificate> GetCertificates(string userOwnerLogin)
        {
            return (from user in context.CitizenUser
                    where user.Login == userOwnerLogin
                    select user)
                   .SingleOrDefault()?.PoliceCertificates;
        }

        public IEnumerable<PoliceCertificate> GetAllValidCertificates(string userOwnerLogin)
        {
            var user = (from u in context.CitizenUser
                        where u.Login == userOwnerLogin
                        select u)
                    .SingleOrDefault();

            if (user == null)
            {
                return null;
            }

            var result = new List<PoliceCertificate>();

            var specialties = user.PoliceCertificates.GroupBy(c => c.Speciality);
            foreach (var spec in specialties)
            {
                result.Add(new PoliceCertificate()
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
