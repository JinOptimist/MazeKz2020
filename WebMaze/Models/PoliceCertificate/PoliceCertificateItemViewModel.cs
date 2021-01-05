using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.PoliceCertificate
{
    public class PoliceCertificateItemViewModel
    {
        public string Speciality { get; set; }

        public DateTime DateOfIssue { get; set; }

        public DateTime? Validity { get; set; }
    }
}
