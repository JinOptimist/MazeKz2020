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
            if (certificate.Id > 0)
            {
                DbSet.Update(certificate);
                await Context.SaveChangesAsync();
                return;
            }

            if (DoesCitizenAlreadyHaveValidCertificate(certificate).Result)
            {
                throw new InvalidOperationException(message: $"The citizen already have valid {certificate.Name}.");
            }

            await DbSet.AddAsync(certificate);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> DoesCitizenAlreadyHaveValidCertificate(Certificate certificate)
        {
            return await DbSet.AnyAsync(c =>
                c.Owner.Id == certificate.Owner.Id && c.Name == certificate.Name &&
                c.Status == CertificateStatus.Valid);
        }
    }
}
