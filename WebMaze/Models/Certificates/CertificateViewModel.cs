using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebMaze.DbStuff.Model;
using WebMaze.DbStuff.Model.UserAccount;
using WebMaze.Models.Account;

namespace WebMaze.Models.Certificates
{
    public class CertificateViewModel
    {
        [Range(0, long.MaxValue)]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        [Required]
        [DisplayName("Issued by")]
        public string IssuedBy { get; set; }

        [DisplayName("Issue Date")]
        public DateTime IssueDate { get; set; }

        [Required]
        [DisplayName("Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        public CertificateStatus Status { get; set; }
        
        [Required]
        [DisplayName("Owner")]
        public string OwnerLogin { get; set; }
    }
}
