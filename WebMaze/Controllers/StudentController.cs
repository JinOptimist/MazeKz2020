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
            meiViewModel.Hegith = 150;
            meiViewModel.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(meiViewModel);

            var diva = new GirlViewModel();
            diva.Name = "diva";
            diva.Hegith = 150;
            diva.Url = "https://upload.wikimedia.org/wikipedia/en/thumb/a/a2/Mei_Overwatch.png/220px-Mei_Overwatch.png";
            models.Add(diva);

            return View(models);
        }

        public IActionResult Batyrov()
        {
            var models = new List<GamesViewModel>();

            var tes = new GamesViewModel()
            {
                Name = "The Elder Scrolls 5. Skyrim",
                Genre = "RPG",
                YearOfRelease = 2011,
                ImageUrl = "https://u.kanobu.ru/editor/images/29/3caaccd8-417b-4170-8fbe-7facfdbdc308.jpg",
                Descriprion = "мультиплатформенная компьютерная ролевая игра с открытым миром, разработанная студией Bethesda Game Studios и выпущенная компанией Bethesda Softworks. Это пятая часть в серии The Elder Scrolls. Игра была выпущена 11 ноября 2011 года для Windows, Playstation 3 и Xbox 360. Для игры были выпущены три загружаемых дополнения под названиями Dawnguard, Hearthfire и Dragonborn, позже объединённых в издании The Elder Scrolls V: Skyrim — Legendary Edition."
            };
            models.Add(tes);

            var witcher = new GamesViewModel()
            {
                Name = "The Witcher",
                Genre = "RPG",
                YearOfRelease = 2015,
                ImageUrl = "https://www.overclockers.ua/news/games/126893-witcher3.jpg",
                Descriprion = "мультиплатформенная компьютерная игра в жанре action/RPG, разработанная польской студией CD Projekt RED по мотивам серии романов «Ведьмак» польского писателя Анджея Сапковского, выпущенная в 2015 году для Windows, PlayStation 4 и Xbox One. Игра является продолжением компьютерных игр «Ведьмак» и «Ведьмак 2: Убийцы королей», заключительной частью трилогии"
            };
            models.Add(witcher);

            var lol = new GamesViewModel()
            {
                Name = "League Of Legends",
                Genre = "MOBA",
                YearOfRelease = 2009,
                ImageUrl = "https://3dnews.ru/assets/external/illustrations/2020/07/25/1016625/01.jpg",
                Descriprion = "сокращённо LoL — ролевая видеоигра с элементами стратегии в реальном времени (MOBA), разработанная и выпущенная компанией Riot Games 27 октября 2009 года для платформ Microsoft Windows и Apple Macintosh[1]. Игра распространяется по модели free-to-play. Ежемесячная аудитория игры составляет 100 млн игроков по всему миру"
            };
            models.Add(lol);


            return View(models);
        }
    }
}
