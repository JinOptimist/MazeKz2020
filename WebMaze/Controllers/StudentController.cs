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

        public IActionResult Akhmetov()
        {
            var buildings = new List<BuildingViewModel>() {
                new BuildingViewModel
                {
                    Name = "Бурдж-Халифа",
                    Description = "Cверхвысотный небоскрёб высотой 828 метров в Дубае (ОАЭ), самое высокое и самое многоэтажное здание в мире.",
                    Url = "https://kuku.travel/wp-content/uploads/2018/07/%D0%9D%D0%B5%D0%B1%D0%BE%D1%81%D0%BA%D1%80%D0%B5%D0%B1-%D0%91%D1%83%D1%80%D0%B4%D0%B6-%D0%A5%D0%B0%D0%BB%D0%B8%D1%84%D0%B0-%D0%B2-%D0%94%D1%83%D0%B1%D0%B0%D0%B5.jpg",
                    Height = 828
                },
                new BuildingViewModel
                {
                    Name = "Шанхайская башня",
                    Description = "Cверхвысокое здание в районе Пудун города Шанхай в Китае.",
                    Url = "https://www.votpusk.ru/gallery/mobile/132311.jpg",
                    Height = 632
                },
                new BuildingViewModel
                {
                    Name = "Часовая королевская башня",
                    Description = "Расположена в городе Мекка, Саудовская Аравия.",
                    Url = "https://islamosfera.ru/wp-content/uploads/2019/12/%D0%90%D0%B1%D1%80%D0%B0%D0%B4%D0%B6-%D0%B0%D0%BB%D1%8C-%D0%91%D0%B5%D0%B9%D1%82-1024x683.jpg",
                    Height = 601
                },
                new BuildingViewModel
                {
                    Name = "Международный финансовый центр Пинань",
                    Description = "Комплекс зданий, включающий 599-метровый, 115-этажный небоскрёб в городе Шэньчжэнь, провинция Гуандун, Китай.",
                    Url = "https://images.adsttc.com/media/images/5a4c/6cb4/b22e/38fb/6600/00e0/large_jpg/3_Ping_An_FC_(c)_Tim_Griffith.jpg?1514957995",
                    Height = 599
                },
                new BuildingViewModel
                {
                    Name = "Lotte World Tower",
                    Description = "123-этажный сверхвысокий небоскрёб, в районе развлекательного комплекса Lotte World в Сеуле, Южная Корея.",
                    Url = "https://i.insider.com/5c12c950a040ff03023de2c9?width=1100&format=jpeg&auto=webp",
                    Height = 555
                },
                new BuildingViewModel
                {
                    Name = "Всемирный торговый центр 1",
                    Description = "Центральное здание в новом комплексе Всемирного торгового центра в нижнем Манхэттене (город Нью-Йорк, США).",
                    Url = "https://aecom.com/wp-content/uploads/2015/10/1WTC_Credit-Michael-Mahesh-PANYNJ-810x531.jpg",
                    Height = 541
                }
            };
            
            return View(buildings.OrderByDescending(building => building.Height).ToList());
        }
    }
}
