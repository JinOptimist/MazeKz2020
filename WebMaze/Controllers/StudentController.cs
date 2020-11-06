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

        public IActionResult Srazhov()
        {
            var models = new List<AnimeGirlViewModel>();
            var names = new string[]
            {
                "Rem",
                "Taiga",
                "Megumin",
            };

            var titleNames = new string[]
            {
                "Ri:Zero kara Hajimeru Isekai Seikatsu",
                "ToraDora",
                "Kono Subarashii Sekai ni Shukufuku wo!"
            };

            var pngUrls = new string[]
            {
                "https://i.pinimg.com/originals/3a/da/82/3ada82dc265205ee239f0f69f373aa31.png",
                "https://pbs.twimg.com/media/ELW4PuaVUAA1M_l.jpg",
                "https://cs10.pikabu.ru/post_img/big/2020/05/01/7/1588333493125556579.png"
            };

            for (int i = 0; i < 3; i++)
            {
                var model = new AnimeGirlViewModel()
                {
                    Name = names[i],
                    Title_Name = titleNames[i],
                    URL_To_PNG = pngUrls[i]
                };

                models.Add(model);
            }

            return View(models);
        }
    }
}
