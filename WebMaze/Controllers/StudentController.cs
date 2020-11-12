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

        public IActionResult Rudich()
        {
            var models = new List<CountryViewModel>();

            var jordanViewModel = new CountryViewModel();
            jordanViewModel.Name = "Jordan";
            jordanViewModel.Continent = "Asia";
            jordanViewModel.Area = 92300;
            jordanViewModel.Url = "https://i.pinimg.com/originals/a5/4c/73/a54c730efc294c758934033455b7eb9d.jpg";
            models.Add(jordanViewModel);

            var indiaViewModel = new CountryViewModel();
            indiaViewModel.Name = "India";
            indiaViewModel.Continent = "South Asia";
            indiaViewModel.Area = 3287263;
            indiaViewModel.Url = "https://www.africanjacana.com/wp-content/uploads/IND.jpg.image_.750.563.low_.jpg";
            models.Add(indiaViewModel);

            return View(models);
        }
    }
}
