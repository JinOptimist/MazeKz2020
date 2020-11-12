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

        public IActionResult Mochalkin()
        {
            var models = new List<HookahViewModel>();

            var maklaudViewModel = new HookahViewModel();
            maklaudViewModel.Name = "Maklaud Skytech";
            maklaudViewModel.Price = 26900;
            maklaudViewModel.Material = "Stainless steel";
            maklaudViewModel.ManufacturerCountry = "Russia";
            maklaudViewModel.Height = 62;
            maklaudViewModel.Url = "https://maklaud.ru/image/cache/catalog/Exlusive/Maklaud%20Skytech/Maklaud%20Skytech%20(7)-400x600.jpg";
            models.Add(maklaudViewModel);

            var vinsentViewModel = new HookahViewModel();
            vinsentViewModel.Name = "Indroduce Vinsent Vega!";
            vinsentViewModel.Price = null;
            vinsentViewModel.Url = "https://i.gifer.com/origin/3e/3e6bcf910e0ba9422b6e1ea79cdc6665_w200.webp";
            models.Add(vinsentViewModel);

            return View(models);
        }
    }
}
