using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMaze.Models.Bus
{
    public class ManageWorkerViewModel
    {   
        public long Id { get; set; }
        public string License { get; set; }

        public string Bus { get; set; }
    }
}
