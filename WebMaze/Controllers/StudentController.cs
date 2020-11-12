using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var models = new List<StudentViewModel>();

            for (int i = 0; i < 5; i++)
            {
                var model = new StudentViewModel();
                model.Second = DateTime.Now.Second + i * 2;
                model.CurentUserName = "Ivan" + i;
                model.DayOfWeek = DateTime.Now.DayOfWeek.ToString();
                models.Add(model);
            }

            return View(models);
        }

        public IActionResult Meiramov()
        {
            var models = new List<GirlViewModel>();

            var meiViewModel = new GirlViewModel();
            meiViewModel.Name = "mei";
            meiViewModel.Hegith  = 150;
            meiViewModel.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(meiViewModel);

            var diva = new GirlViewModel();
            diva.Name = "diva";
            diva.Hegith = 150;
            diva.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(diva);

            return View(models);
        }

        public IActionResult Karayev()
        {
            var models = new List<BucsTeamCaptainViewModel>();

            var tomBrady = new BucsTeamCaptainViewModel
            {
                Name = "Tom Brady",
                Position = "Quarterback / Offense",
                College = "Michigan",
                Experience = 21,
                PhotoURL = "https://i.ibb.co/m9v7CNV/TomBrady.webp"
            };
            var mikeEvans = new BucsTeamCaptainViewModel
            {
                Name = "Mike Evans",
                Position = "Wide Receiver / Offense",
                College = "Texas A&M",
                Experience = 7,
                PhotoURL = "https://i.ibb.co/5LfnR8j/Mike-Evans.webp"
            };
            var lavonteDavid = new BucsTeamCaptainViewModel
            {
                Name = "Lavonte David",
                Position = "Linebacker / Defense",
                College = "Nebraska",
                Experience = 9,
                PhotoURL = "https://i.ibb.co/PwKWRTM/Lavonte-David.webp",
            };
            var devinWhite = new BucsTeamCaptainViewModel
            {
                Name = "Devin White",
                Position = "Linebacker / Defense",
                College = "LSU",
                Experience = 2,
                PhotoURL = "https://i.ibb.co/892CCqC/Devin-White.webp",
            };
            var kevinMinter = new BucsTeamCaptainViewModel
            {
                Name = "Kevin Minter",
                Position = "Linebacker / Special Teams",
                College = "LSU",
                Experience = 8,
                PhotoURL = "https://i.ibb.co/P1S1YNR/Kevin-Minter.webp",
            };
            var bradleyPinion = new BucsTeamCaptainViewModel
            {
                Name = "Bradley Pinion",
                Position = "Punter / Special Teams",
                College = "Clemson",
                Experience = 6,
                PhotoURL = "https://i.ibb.co/MZ745my/Bradley-Pinion.webp",
            };
            models.AddRange(new List<BucsTeamCaptainViewModel>{
                            tomBrady,
                            mikeEvans,
                            lavonteDavid,
                            devinWhite,
                            kevinMinter,
                            bradleyPinion});

            return View(models);
        }
    }
}
