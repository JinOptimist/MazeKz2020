using System;
using WebMaze.Models.Account;

namespace WebMaze.Models.Police
{
    public class PolicemanViewModel 
    {
        public ProfileViewModel ProfileVM { get; set; }

        public bool HasValidCertificate => DateOfIssue.HasValue;

        public string Rank { get; set; }

        public DateTime? DateOfIssue { get; set; }

        public DateTime? Validity { get; set; }
    }
}
