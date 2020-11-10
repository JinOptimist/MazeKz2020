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

        public IActionResult Proshutin()
        {
            var countries = new List<CountryViewModel>();

            var germany = new CountryViewModel("Germany", "Berlin", 81_770_900, "https://restcountries.eu/data/deu.svg", 357114.0);
            countries.Add(germany);
            var switzerland = new CountryViewModel("Switzerland", "Bern", 8_341_600, "https://restcountries.eu/data/che.svg", 41284.0);
            countries.Add(switzerland);
            var austria = new CountryViewModel("Austria", "Vienna", 8_725_931, "https://restcountries.eu/data/aut.svg", 83871.0);
            countries.Add(austria);
            var poland = new CountryViewModel("Poland", "Warsaw", 38_437_239, "https://restcountries.eu/data/pol.svg", 312679.0);
            countries.Add(poland);
            var ukraine = new CountryViewModel("Ukraine", "Kiev", 42_692_393, "https://restcountries.eu/data/ukr.svg", 603700.0);
            countries.Add(ukraine);
            var georgia = new CountryViewModel("Georgia", "Tbilisi", 3_720_400, "https://restcountries.eu/data/geo.svg", 69700.0);
            countries.Add(georgia);
            var turkey = new CountryViewModel("Turkey", "Ankara", 78_741_053, "https://restcountries.eu/data/tur.svg", 783562.0);
            countries.Add(turkey);
            var israel = new CountryViewModel("Israel", "Jerusalem", 8_527_400, "https://restcountries.eu/data/isr.svg", 20770.0);
            countries.Add(israel);
            var thailand = new CountryViewModel("Thailand", "Bangkok", 65_327_652, "https://restcountries.eu/data/tha.svg", 513120.0);
            countries.Add(thailand);
            var britain = new CountryViewModel("United Kingdom", "London", 65_110_000, "https://restcountries.eu/data/gbr.svg", 242900.0);
            countries.Add(britain);
            var russia = new CountryViewModel("Russian Federation", "Moscow", 146_599_183, "https://restcountries.eu/data/rus.svg", 17124442.0);
            countries.Add(russia);
            var indonesia = new CountryViewModel("Indonesia", "Jakarta", 258_705_000, "https://restcountries.eu/data/idn.svg", 1904569.0);
            countries.Add(indonesia);

            return View(countries);
        }
    }
}
