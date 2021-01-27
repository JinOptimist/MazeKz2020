using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMaze.DbStuff.Model.UserAccount;

namespace WebMaze.DbStuff.Repository
{
    public class CertificateRepository : AsyncBaseRepository<Certificate>
    {
        public CertificateRepository(WebMazeContext context) : base(context)
        {
        }

        public override async Task SaveAsync(Certificate certificate)
        {
            if (DoesCitizenAlreadyHaveValidCertificateAsync(certificate).Result)
            {
                throw new InvalidOperationException(message: $"The citizen already have valid {certificate.Name}.");
            }

            if (certificate.Id > 0)
            {
                DbSet.Update(certificate);
                await Context.SaveChangesAsync();
                return;
            }

            await DbSet.AddAsync(certificate);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> DoesCitizenAlreadyHaveValidCertificateAsync(Certificate certificate)
        {
            return await DbSet.AnyAsync(c =>
                c.Name == certificate.Name && c.Owner.Id == certificate.Owner.Id &&
                c.Status == CertificateStatus.Valid && c.Id != certificate.Id);
        }

        public async Task<List<Certificate>> GetCertificatesByNameAsync(string certificateName)
        {
            return await DbSet.Where(certificate => certificate.Name == certificateName).ToListAsync();
        }

        public async Task<List<Certificate>> GetUserCertificatesAsync(string userLogin)
        {
            return await DbSet.Where(certificate => certificate.Owner.Login == userLogin).ToListAsync();
        }
    }
}
